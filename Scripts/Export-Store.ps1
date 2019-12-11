
$prgPath="C:\Program Files (x86)\Enrollment Station v0.4.0.0"

[Reflection.Assembly]::LoadFile("$prgPath\Newtonsoft.Json.dll")
$logDate = get-date -f yyyyMMddhhmm


$csvfile = "$($prgPath)\export-puk_$logDate.csv" 

# list to export
$longlist = @()


# Main
function ConvertFrom-JObject($obj) {
   if ($obj -is [Newtonsoft.Json.Linq.JArray]) {
        $a = @()
        foreach($entry in $obj.GetEnumerator()) {
            $a += @(convertfrom-jobject $entry)
        }
        return $a
   }
   elseif ($obj -is [Newtonsoft.Json.Linq.JObject]) {
       $h = [ordered]@{}
       foreach($kvp in $obj.GetEnumerator()) {
            $val =  convertfrom-jobject $kvp.value
            if ($kvp.value -is [Newtonsoft.Json.Linq.JArray]) { $val = @($val) }
            $h += @{ "$($kvp.key)" = $val }
       }
       return $h
   }
   elseif ($obj -is [Newtonsoft.Json.Linq.JValue]) {
        return $obj.Value
   }
   else {
    return $obj
   }
}

function ConvertFrom-JsonNewtonsoft([Parameter(Mandatory=$true,ValueFromPipeline=$true)]$string) {
$obj = [Newtonsoft.Json.JsonConvert]::DeserializeObject($string, [Newtonsoft.Json.Linq.JObject])
    
    return ConvertFrom-JObject $obj
}

function ConvertTo-JsonNewtonsoft([Parameter(Mandatory=$true,ValueFromPipeline=$true)]$obj) {
    return [Newtonsoft.Json.JsonConvert]::SerializeObject($obj, [Newtonsoft.Json.Formatting]::Indented)
}

#Main

$f = [System.IO.File]::ReadAllText("$($prgPath)\store.json")
$r=ConvertFrom-JsonNewtonsoft($f)
$list=$r.YubiKeys


for ($i=0;$i -lt $list.count;$i++)
{
  $d = $list.DeviceSerial[$i]
  $u = $list.username[$i]
  $p = $list.PukKey[$i]
  $m = $list.ManagementKey[$i]
  $e = [Convert]::FromBase64String($m)
  $f = [BitConverter]::ToString($e).Replace("-","") 
 
  $details = @{            
           serialnr = $d                        
           username = $u
           pukkey = $p
           managekey = $f
        }  
   $longlist += New-Object PSObject -Property $details  
}


$longlist | Export-Csv -Path $csvfile -NoTypeInformation -Encoding UTF8 -force

