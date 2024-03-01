using System;

namespace PCCC.Common.Utils
{
    public class JsonResponse
    {

        // Trạng Thái Thành Công :
        public static JsonResultModel Success(object data)
        {
            return new JsonResultModel(PCCCConsts.SUCCESS, PCCCConsts.SUCCESS_CODE, PCCCConsts.MESSAGE_SUCCESS, data);
        }

        public static JsonResultModel Success(string message, object data)
        {
            return new JsonResultModel(PCCCConsts.SUCCESS, PCCCConsts.SUCCESS_CODE, message, data);
        }
        public static JsonResultModel Success(int code, object data)
        {
            return new JsonResultModel(PCCCConsts.SUCCESS, code, PCCCConsts.MESSAGE_SUCCESS, data);
        }
        public static JsonResultModel Success()
        {
            return new JsonResultModel(PCCCConsts.SUCCESS, PCCCConsts.SUCCESS_CODE, PCCCConsts.MESSAGE_SUCCESS, "");
        }
        // Trạng thái không thành công:
        public static JsonResultModel Error(int code, string message)
        {
            return new JsonResultModel(PCCCConsts.ERROR, code, message, "");
        }

        public static JsonResultModel Response(int status, int code, string message, object data)
        {
            return new JsonResultModel(status, code, message, data);
        }

        public static JsonResultModel ServerError()
        {
            return new JsonResultModel(PCCCConsts.ERROR, PCCCConsts.ERROR_CODE, PCCCConsts.SERVER_ERROR, "");
        }

    }
}
