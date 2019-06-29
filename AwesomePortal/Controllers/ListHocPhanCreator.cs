﻿using AwesomePortal.Models;
using AwesomePortal.Utils;
using AwesomePortal.Utils.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Controllers
{
    class ListHocPhanCreator
    {
        private SinhVien sinhVien;
        public ListHocPhanCreator()
        {

        }

        public class HocPhanExtend
        {
            public HocPhan hocPhan { get; set; }
            // Lý do không được phép đăng ký
            public string lyDo { get; set; }
        }

        public ListHocPhanCreator(SinhVien sv)
        {
            sinhVien = sv;
        }

        public async Task<List<HocPhan>> getListRegisteredAsync()
        {
            try
            {
                List<HocPhan> listHocPhan = new List<HocPhan>();
                BaseConnector connector = BaseConnector.getInstance();
                List<Object> listO = await connector.GetListObject("listmon");
                for(int i = 0; i < listO.Count; i++)
                {
                    listHocPhan.Add(HocPhan.Parse(listO[i]));
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }

        public async Task<List<HocPhan>> getListRegistableAsync()
        {
            try
            {
                List<HocPhan> listHocPhan = new List<HocPhan>();
                BaseConnector connector = BaseConnector.getInstance();
                List<Object> listO = await connector.GetListObject("listmonchuadk");
                for (int i = 0; i < listO.Count; i++)
                {
                    listHocPhan.Add(HocPhan.Parse(listO[i]));
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }

        public async Task<List<HocPhanExtend>> getListUnRegistableAsync()
        {
            try
            {
                List<HocPhanExtend> listHocPhan = new List<HocPhanExtend>();
                BaseConnector connector = BaseConnector.getInstance();
                List<Object> listO = await connector.GetListObject("listmonkhongthedk");
                for (int i = 0; i < listO.Count; i++)
                {
                    HocPhanExtend hocPhan = new HocPhanExtend()
                    {
                        hocPhan = HocPhan.Parse(listO[i]),
                        lyDo = JsonGetter.getString(listO[i].ToString(), "lyDo")
                    };
                    listHocPhan.Add(hocPhan);
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }
    }
}
