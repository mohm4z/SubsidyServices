﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Common;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Common
{
    public class CommonDAL : IDisposable
    {
        public readonly IADO ado;

        public CommonDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public IEnumerable<LookupTable> GetLookupDAL(
            string ApplicationCode,
            int TabNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_APPLICATION_CODE  " , VALUE = ApplicationCode},
                new SpInPuts(){KEY = "P_TAB_NO" , VALUE = TabNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_LOOKUPS",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<LookupTable>();
        }

        public IEnumerable<LookupTable> GetSubLookupDAL(
            string ApplicationCode,
            int TabNumber,
            int SubTabNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_APPLICATION_CODE  " , VALUE = ApplicationCode},
                new SpInPuts(){KEY = "P_TAB_NO" , VALUE = TabNumber},
                new SpInPuts(){KEY = "P_SUBTAB_NO" , VALUE = SubTabNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_LOOKUPS_DET",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<LookupTable>();
        }

        public AgencyInfo GetAgencyInfoDAL(
            int AgencyType,
            long AgencyLicenseNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = AgencyLicenseNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_BRN_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_SOC_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_REGISTRY_DT" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_SERVICE_AREA" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_SUBSIDY_ACC_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_BANK_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_CAT_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_NO_700" , OracleDbType= OracleDbType.Varchar2 , Size = 300},

                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_CH_REG_INFO",
                OpParms,
                out OracleParameterCollection OPCs
                );

            AgencyInfo chi = new AgencyInfo
            {
                DevelopmentCenterName = OPCs[":P_BRN_NAME"].Value.ToString(),
                CharityName = OPCs[":P_SOC_NAME"].Value.ToString(),
                LicenseDate = OPCs[":P_REGISTRY_DT"].Value.ToString(),
                ServiceArea = OPCs[":P_SERVICE_AREA"].Value.ToString(),
                BankAccountNumber = OPCs[":P_SUBSIDY_ACC_NO"].Value.ToString(),
                BankName = OPCs[":P_BANK_NAME"].Value.ToString(),
                CharityClassification = OPCs[":P_CAT_NAME"].Value.ToString(),
                AccountNumber700 = OPCs[":P_NO_700"].Value.ToString(),

                RequestResult = new RequestResult()
                {
                    RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }

        public AgencyGoals GetAgencyGoalsDAL(
            int AgencyType,
            long AgencyLicenseNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = AgencyLicenseNumber},
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_REG_GOALS",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            AgencyGoals chi = new AgencyGoals
            {
                Goals = Ds.Tables[0].DataTableToList<Goals>(),
                RequestResult = new RequestResult()
                {
                    RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }

        public AgencyFiles GetAgencyFilesDAL(
            long SubsidyCode
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = SubsidyCode}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_SUBSIDY_FILES",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            AgencyFiles chi = new AgencyFiles
            {
                Files = Ds.Tables[0].DataTableToList<Files>(),
                RequestResult = new RequestResult()
                {
                    RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                    RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
                }
            };

            return chi;
        }

        public RequestPreviousStatus CheckPreviousRequestsStatusDAL(
            int CheckType,
            int AgencyType,
            long AgencyLicenseNumber,
            int SubsidyCode
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_TRANS_TYPE" , VALUE = CheckType},
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = SubsidyCode}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_STATUS" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_CHK_REQUEST_APPROVED",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestPreviousStatus chi = new RequestPreviousStatus
            {
                RequestStatus = OPCs[":P_RESULT_STATUS"].Value.ToString(),
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString()
            };

            return chi;
        }

        public IEnumerable<FinancialYears> GetFinancialYearsDAL(
            int AgencyType
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "SD_P_GET_FIN_YEARS",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<FinancialYears>();
        }

        public string NumberToTextDAL(
            decimal Number
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_NUMBER" , VALUE = Number}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_NUMBER_TO_TEXT",
                OpParms,
                out OracleParameterCollection OPCs
                );

            return OPCs[":P_TEXT"].Value.ToString();
        }

        public IEnumerable<Request> GetPreviousRequestsDAL(
            int AgencyType,
            long AgencyLicenseNumber,
            string SubsidyCode,
            string RequestsStatusId
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_SOC_REG_NO" , VALUE = AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = SubsidyCode},
                new SpInPuts(){KEY = "P_REQUEST_STATUS_CD" , VALUE = RequestsStatusId}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_REQUESTS_STATUS",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<Request>();
        }

        public IEnumerable<Subsidy> CheckSubsidyInfoDAL(
            int? AgencyType,
            int? SubsidyCode
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = AgencyType},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = SubsidyCode},
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RECORDSET" , OracleDbType= OracleDbType.RefCursor , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
                );

            ado.ExecuteStoredProcedure(
                "CH_P_GET_SUBSIDY_TYPES",
                OpParms,
                out OracleParameterCollection OPCs,
                out DataSet Ds
                );

            return Ds.Tables[0].DataTableToList<Subsidy>();
        }

        public IsDelegatorAuthorizedResult IsDelegatorAuthorizedDAL(
            DelegatorInfo obj
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = obj.REG_ID},
                new SpInPuts(){KEY = "P_DLGT_ID" , VALUE = obj.DLGT_ID},
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = obj.REG_TYPE_CODE},
                new SpInPuts(){KEY = "P_SUBSIDY_CODE" , VALUE = obj.SUBSIDY_CODE}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_REG_DT" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_SOC_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_BRN_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_MOBILE_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_DLGT_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000}
            };

            //Populate Parameters
            List<OracleParameter> OpParms = ado.PopulateSpInPuts(
                in inputs
                );

            ado.PopulateSpOutPuts(
                ref OpParms,
                in Outouts
              );

            ado.ExecuteStoredProcedure(
                "CH.PRC_GET_ORG_INFO",
                OpParms,
                out OracleParameterCollection OPCs
                );

            IsDelegatorAuthorizedResult rs = new IsDelegatorAuthorizedResult()
            {
                REG_DT = OPCs[":P_REG_DT"].Value.ToString(),
                SOC_NAME = OPCs[":P_SOC_NAME"].Value.ToString(),
                BRN_NAME = OPCs[":P_BRN_NAME"].Value.ToString(),
                MOBILE_NO = OPCs[":P_MOBILE_NO"].Value.ToString(),
                DLGT_NAME = OPCs[":P_DLGT_NAME"].Value.ToString(),
                MESSAGE_CODE = OPCs[":P_RESULT_CODE"].Value.ToString(),
                MESSAGE_DESC = OPCs[":P_RESULT_TEXT"].Value.ToString()
            };

            return rs;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
