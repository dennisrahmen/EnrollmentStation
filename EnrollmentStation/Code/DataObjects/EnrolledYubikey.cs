﻿using System;
using System.Xml.Serialization;

namespace EnrollmentStation.Code.DataObjects
{
    [Serializable]
    public class EnrolledYubikey
    {
        [XmlAttribute]
        public int DeviceSerial { get; set; }

        [XmlAttribute]
        public string Username { get; set; }

        [XmlAttribute]
        public string CA { get; set; }

        [XmlAttribute]
        public string Slot { get; set; }

        [XmlAttribute]
        public byte[] ManagementKey { get; set; }

        [XmlAttribute]
        public string Chuid { get; set; }

        [XmlAttribute]
        public string PukKey { get; set; }

        [XmlAttribute]
        public DateTime EnrolledAt { get; set; }

        public YubikeyVersions YubikeyVersions { get; set; }

        public CertificateDetails Certificate { get; set; }

        public EnrolledYubikey()
        {
            YubikeyVersions = new YubikeyVersions();
            Certificate = new CertificateDetails();
        }
    }
}