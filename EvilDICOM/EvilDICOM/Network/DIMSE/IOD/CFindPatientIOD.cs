﻿using EvilDICOM.Core.Element;
using EvilDICOM.Network.DIMSE.IOD;
using System;
using System.Collections.Generic;
using System.Text;
using S = System;
using DF = EvilDICOM.Core.DICOMForge;
using EvilDICOM.Network.Enums;
using EvilDICOM.Core;
using EvilDICOM.Core.Helpers;

namespace EvilDICOM.Network.DIMSE.IOD
{
    public class CFindPatientIOD : CFindRequestIOD
    {
        public CFindPatientIOD() : base()
        {
            QueryLevel = QueryLevel.PATIENT;
            PatientId = string.Empty;
            PatientSex = string.Empty;
            PatientBirthDate = null;
            PatientsName = new PersonName(TagHelper.PatientName, string.Empty);
        }

        public CFindPatientIOD(DICOMObject dcm) : base(dcm, QueryLevel.PATIENT)
        {
        }

        public PersonName PatientsName
        {
            get { return _sel.PatientName != null ? _sel.PatientName : null; }
            set { _sel.PatientName = value; }
        }

        public string PatientId
        {
            get { return _sel.PatientID != null ? _sel.PatientID.Data : null; }
            set { _sel.Forge(DF.PatientID(value)); }
        }

        public string PatientSex
        {
            get { return _sel.PatientSex != null ? _sel.PatientSex.Data : null; }
            set { _sel.Forge(DF.PatientSex(value)); }
        }

        public S.DateTime? PatientBirthDate
        {
            get { return _sel.PatientBirthDate != null ? _sel.PatientBirthDate.Data : null; }
            set { _sel.Forge(DF.PatientBirthDate(value)); }
        }
    }
}
