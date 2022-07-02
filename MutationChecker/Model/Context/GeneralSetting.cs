using MutationChecker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutationChecker.Model.Context
{
    public class GeneralSetting : MCContext
    {
        public static void InsertToken(string token)
        {
            try
            {
                var q = $"INSERT INTO general_setting (gs_key, gs_value) VALUES('bearer_token', '{token}')";
                InsertData(q);
            }
            catch(Exception ex)
            {

            }
        }

        public static GeneralSettingDTO GetToken()
        {
            var dto = new GeneralSettingDTO();
            try
            {
                var q = $"select * from general_setting where gs_key = 'bearer_token'";
                var dr = ReadData(q);

                if (dr.Read())
                {
                    dto.GsKey = "bearer_token";
                    dto.GsValue = dr["gs_value"].ToString();
                }
                dr.Close();

                CloseConnection();
            }
            catch(Exception ex)
            {

            }

            return dto;
        }
    }
}
