﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DbManager;
using Models.Common;
using Models.Cooperative;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.Cooperative
{
    public class CooperativeDAL : IDisposable
    {
        public readonly IADO ado;

        public CooperativeDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public RequestResult InsertProjectsSupportDAL(
             ProjectInfo prj,
             List<Files> Files
             )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = prj.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = prj.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = prj.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = prj.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "CEO_NAME" , VALUE = prj.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "CEO_MOB_NO" , VALUE = prj.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "ECONOMIC_FEASIBILITY_FLG" , VALUE = prj.IsThereFeasibilityStudy},
                new SpInPuts(){KEY = "PROJ_TYPE" , VALUE = prj.ProjectType},
                new SpInPuts(){KEY = "PROJ_DESC" , VALUE = prj.ProjectDescription},
                new SpInPuts(){KEY = "PROJ_LOCATION" , VALUE = prj.ProjectLocation},
                new SpInPuts(){KEY = "PROJ_EXEC_REGION" , VALUE = prj.ExecutingAgency},
                new SpInPuts(){KEY = "PROJ_AGREE_FLG" , VALUE = prj.ImplementProjectAgreement},
                new SpInPuts(){KEY = "PROJ_ACTUAL_COST" , VALUE = prj.ActualCost},
                new SpInPuts(){KEY = "PROJ_STAGES_FUND" , VALUE = prj.DistributeAmountsOnStages},
                new SpInPuts(){KEY = "PROJ_EXPNS_CMBTL_FLG" , VALUE = prj.IsExpendedIdenticalBudget},
                new SpInPuts(){KEY = "PROJ_REG_SHARE_AMNT" , VALUE = prj.AmountForProject},
                new SpInPuts(){KEY = "PROJ_EXPEND_BAL_AMNT" , VALUE = prj.AmountExpendedOnBudget},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = prj.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Varchar2 , Size = 300}
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
                "CS_P_SUBSIDY_PROJECTS",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    prj.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return chi;
        }


        public RequestResult InsertFoundationCooperativeDAL(
            FoundationInfo FoundationInfo,
            List<Files> Files
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REG_TYPE_CODE" , VALUE = FoundationInfo.CheckedData.AgencyType},
                new SpInPuts(){KEY = "P_REG_ID" , VALUE = FoundationInfo.CheckedData.AgencyLicenseNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_MOBILE" , VALUE = FoundationInfo.ManagersInfo.ChairmanBoardMobileNumber},
                new SpInPuts(){KEY = "P_BOARD_CHAIRMAN_NAME" , VALUE = FoundationInfo.ManagersInfo.ChairmanBoardName},
                new SpInPuts(){KEY = "CEO_NAME" , VALUE = FoundationInfo.ManagersInfo.ExecutiveDirectorName},
                new SpInPuts(){KEY = "CEO_MOB_NO" , VALUE = FoundationInfo.ManagersInfo.ExecutiveDirectorMobile},
                new SpInPuts(){KEY = "CEO_MOB_NO" , VALUE = FoundationInfo.CompanyCapitalInBeginning},
                new SpInPuts(){KEY = "P_ESTBLSH_CAPITAL" , VALUE = FoundationInfo.CheckedData.CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
                new SpOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 300},
                new SpOutPuts() { ParameterName ="P_RESULT_TEXT" , OracleDbType= OracleDbType.Varchar2 , Size = 2000},
                new SpOutPuts() { ParameterName ="P_REQUEST_ID" , OracleDbType= OracleDbType.Varchar2 , Size = 300}
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
                "CS_P_SUBSIDY_ESTBLSH",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult chi = new RequestResult
            {
                RequestId = OPCs[":P_REQUEST_ID"].Value != null ? Convert.ToInt64(OPCs[":P_REQUEST_ID"].Value.ToString()) : 0,
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            for (int i = 0; i < Files.Count(); i++)
            {
                InsertAttachmentDAL(
                    chi.RequestId,
                    Files[i].Id,
                    Files[i].Path,
                    FoundationInfo.CheckedData.CommissionerNumber.ToString()
                    );
            }

            return chi;
        }


        public RequestResult InsertAttachmentDAL(
            long RequestId,
            int FileNumber,
            string FilePath,
            string CommissionerNumber
            )
        {
            List<SpInPuts> inputs = new List<SpInPuts>
            {
                new SpInPuts(){KEY = "P_REQUEST_ID" , VALUE = RequestId},
                new SpInPuts(){KEY = "P_FILE_CODE" , VALUE = FileNumber},
                new SpInPuts(){KEY = "P_FILE_PATH" , VALUE = FilePath},
                new SpInPuts(){KEY = "P_LOGIN_ID" , VALUE = CommissionerNumber}
            };

            List<SpOutPuts> Outouts = new List<SpOutPuts>()
            {
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
                "CH_P_SUBSIDY_ATTACHS",
                OpParms,
                out OracleParameterCollection OPCs
                );

            RequestResult chi = new RequestResult
            {
                RequestCode = OPCs[":P_RESULT_CODE"].Value.ToString(),
                RequestName = OPCs[":P_RESULT_TEXT"].Value.ToString(),
            };

            return chi;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
