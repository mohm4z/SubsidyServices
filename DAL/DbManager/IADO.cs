﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using Models.SpParameters;
using Oracle.ManagedDataAccess.Client;

namespace DAL.DbManager
{
    public interface IADO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statment"></param>
        /// <returns></returns>
        bool SqlCommand(
            string Statment
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP_NAME"></param>
        /// <param name="parms"></param>
        /// <param name="OPC"></param>
        void ExecuteStoredProcedure(
            in string SP_NAME,
            in List<OracleParameter> parms,
            out OracleParameterCollection OPC
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SP_NAME"></param>
        /// <param name="parms"></param>
        /// <param name="OPC"></param>
        /// <param name="DS"></param>
        void ExecuteStoredProcedure(
            in string SP_NAME,
            in List<OracleParameter> parms,
            out OracleParameterCollection OPC,
            out DataSet DS
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Commite"></param>
        /// <returns></returns>
        bool SqlCommiteT(
            bool Commite
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statment"></param>
        /// <returns></returns>
        DataTable SqlSelect(
            string Statment
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statment"></param>
        /// <returns></returns>
        DataRow SqlSelectOneRow(
            string Statment
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Statment"></param>
        /// <returns></returns>
        object SqlSelectOneValue(
            string Statment
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object Nullable(
            object value
            );


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OpParams"></param>
        /// <param name="InPuts"></param>
        List<OracleParameter> PopulateSpInPuts(
            in List<SpInPuts> InPuts
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OutPuts"></param>
        /// <returns></returns>
        void PopulateSpOutPuts(
              ref List<OracleParameter> OpParams,
             in List<SpOutPuts> OutPuts
             );

        void PopulateSpInOutPuts(
            ref List<OracleParameter> OpParams,
            in List<SpInOutPuts> InOutPuts
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OPCs"></param>
        /// <returns></returns>
        ExpandoObject CreateExapoClass(
            ref OracleParameterCollection OPCs
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OPCs"></param>
        /// <returns></returns>
        XElement CreateXElement(
            in string T_NAME,
            ref OracleParameterCollection OPCs
           );
    }
}
