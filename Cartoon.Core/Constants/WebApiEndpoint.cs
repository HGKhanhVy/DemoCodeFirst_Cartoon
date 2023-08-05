namespace Cartoon.Core.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class PhimHoatHinh
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phim-hoat-hinh";
            public const string GetPhimHoatHinh = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllPhimHoatHinh = BaseEndpoint + "/get-all";
            public const string AddPhimHoatHinh = BaseEndpoint + "/add";
            public const string UpdatePhimHoatHinh = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeletePhimHoatHinh = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class TapPhim
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tap-phim";
            public const string GetTapPhim = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllTapPhim = BaseEndpoint + "/get-all";
            public const string AddTapPhim = BaseEndpoint + "/add";
            public const string UpdateTapPhim = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteTapPhim = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class NhanVatTrongTapPhim
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhan-vat-trong-tap-phim";
            public const string GetNhanVatTrongTapPhim = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhanVatTrongTapPhim = BaseEndpoint + "/get-all";
            public const string AddNhanVatTrongTapPhim = BaseEndpoint + "/add";
            public const string UpdateNhanVatTrongTapPhim = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhanVatTrongTapPhim = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class NhanVat
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhan-vat";
            public const string GetNhanVat = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhanVat = BaseEndpoint + "/get-all";
            public const string AddNhanVat = BaseEndpoint + "/add";
            public const string UpdateNhanVat = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhanVat = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class DienVienTGLongTieng
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dien-vien-tg-long-tieng";
            public const string GetDienVienTGLongTieng = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDienVienTGLongTieng = BaseEndpoint + "/get-all";
            public const string AddDienVienTGLongTieng = BaseEndpoint + "/add";
            public const string UpdateDienVienTGLongTieng = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDienVienTGLongTieng = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class DienVienLongTieng
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dien-vien";
            public const string GetDienVienLongTieng = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDienVienLongTieng = BaseEndpoint + "/get-all";
            public const string AddDienVienLongTieng = BaseEndpoint + "/add";
            public const string UpdateDienVienLongTieng = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDienVienLongTieng = BaseEndpoint + "/delete" + "/{keyId}";
        }
    }
}