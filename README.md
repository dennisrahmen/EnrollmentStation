# Enrollment Station using YubiKey Smart Cards
A Smart Card enrollment station for use in enterprises with Microsoft Active Directory Certificate Services and certificate-based logons. This software package will streamline some operations such as enrolling and terminating Smart Card devices.

This project is an entry in the YubiKing 2015 competition and should be considered a work in progress.

### Note
The original project is archived. (https://github.com/CSIS/EnrollmentStation)   
This version is a forked project from scVENUS. We added some new features.

* You can save one or two certificates on one YubiKey
* Store and settings file are now encrypted
* New metro style design

### Dependencies
* Windows PKI (Active Directory Certificate Services)
* Enrollment Agent Certificate (see prerequisites)
* CCID smart cards from Yubico (currently Yubikey NEO, Yubikey 4 and Yubikey 5 NFC)
* (optional) YubiHSM

## Download
You can find the latest binaries at our [releases page](https://github.com/jnsgsbz/EnrollmentStation/releases). 

## Prerequisites
To use this tool you will need an Enrollment Agent Certificate which allows you to enroll certificates on behalf of other users. This certificate template is available on a default Active Directory Certificate Services (Windows CA) installation but is normally not permitted for any users other than Domain Admins. For additional security, create a dedicated user which is used as the enrollment station user.

**A. Setup Enrollment Agent certificate template permissions**

1. Log on to your Windows Certificate Authority
2. Open the Certificate Authority control panel
3. Right-click the `Certificate Templates` folder and chose `Manage`
4. Find the `Enrollment Agent` template, right-click on it and chose `Properties`
5. In the security tab, allow your enrollment station user to enroll the certificate.

After a while, the template should be available to the enrollment station user through the Certificates snap-in in MMC.

**B. Enroll the Enrollment Agent certificate**

1. Log on to your enrollment station as your enrollment user and open MMC.
2. In MMC, add the Certificates snap-in for the current user, and expand the Personal folder.
3. Right-click on the Certificates folder and chose `Request new Certificate`. Follow the wizard, and select the `Enrollment Agent` template when asked for a template.

After setting up the Enrollment Agent certificate, you need a YubiKey set to CCID Smart Card mode.

**C. Changing YubiKey to CCID Smart Card mode**

1. Download YubiKey YubiKey Manager from here https://developers.yubico.com/yubikey-manager/
2. In the GUI application (ykman-gui.exe) under `Interfaces` select on the left USB section `PIV`
3. Save the new settings with click on `Save Interfaces`

Alternatively use the CLI application (ykman.exe) and enter `ykman mode CCID`

You can also read our manual to find methods with accompanying screenshots.

## Documentation
See the pdf manual, at [Manual-GUI.pdf](Manual-GUI.pdf)

## Used open source projects

This project makes use of the following open source projects

* [Active Directory Object picker](https://github.com/Tulpep/Active-Directory-Object-Picker)
* [MetroFramework](https://github.com/thielj/MetroFramework)

## Todo
* Handle more diverse PKI setups
* Describe revoke procedure and requirements thereto (permissions, COM object .. )

