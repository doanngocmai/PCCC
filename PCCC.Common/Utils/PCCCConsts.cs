using System;
using System.Collections.Generic;
using System.Text;

namespace PCCC.Common.Utils
{
    public class PCCCConsts
    {
        #region -- CONSTANT --
        // Notification
        public const int NOTI_READ = 1;
        public const int NOTI_NOT_READ = 0;

        public const int NOTI_ADMIN = 1;
        public const int NOTI_CUSTOMER = 0;

        public const int PAGE_DEFAULT = 1;
        public const int LIMIT_DEFAULT = 10;
        // Upload File
        public const string FILE_NAME = "Images";
        public const string FILE = "file";
        
        public const int ACTIVE = 1;
        public const int ACTIVE_FALSE = 0;

        public const int SORT_ASCENDING = 1;
        public const int SORT_DESCENDING = 2;

        public const string CONVERT_DATETIME = "dd/MM/yyyy";
        public const string CONVERT_DATETIME_HAVE_HOUR = "HH:mm dd/MM/yyyy";

        // OTP
        public const int OTP_MAX_QUANTITY = 5;

        // Token Type
        public const string TOKEN_TYPE_CUSTOMER = "1";
        public const string TOKEN_TYPE_USER = "2";

        // Customer
        public const int CUSTOMER_ORIGIN_REGISTER = 1; // Sử dụng App
        public const int CUSTOMER_ORIGIN_PG = 2; // PG tạo


        public const int NEWS_TYPEPOST_POSTED = 2; //  Đăng bài  
        public const int NEWS_TYPEPOST_DRAFT = 1;  //  Lưu nháp

        // Price
        public const long MILLION = 1000000;
     
        // Status
        public const int Status_Activate = 1;

        #endregion
        #region -- API RESPONSE --

        // Default
        public const int SUCCESS = 1;
        public const int ERROR = 0;
        public const int SUCCESS_CODE = 200;
        public const string MESSAGE_SUCCESS = "Thành công";
        public const int ERROR_CODE = 501;
        public const string MESSAGE_ERROR = "Thất bại";
        public const string SERVER_ERROR = "Hệ thống đang bảo trì";
        public const int TOKEN_INVALID = 401;
        public const string MESSAGE_TOKEN_INVALID = "Đăng nhập để thực hiện chức năng này";
        public const int PERMISSION_INVALID = 402;
        public const string MESSAGE_PERMISSION_INVALID = "Bạn không có quyền thực hiện chức năng này";
        public const int TOKEN_ERROR = 403;
        public const string MESSAGE_TOKEN_ERROR = "Tài khoản của bạn đã đăng nhập ở nơi khác";

        // Login
        public const int ERROR_LOGIN_FIELDS_INVALID = 1;
        public const string MESSAGE_LOGIN_FIELDS_INVALID = "Vui lòng nhập số điện thoại";
        public const int ERROR_LOGIN_FAIL = 2;
        public const string MESSAGE_LOGIN_FAIL = "Số điện thoại không tồn tại";
        public const int ERROR_LOGIN_ACCOUNT_LOCK = 3;
        public const string MESSAGE_LOGIN_ACCOUNT_LOCK = "Tài khoản đã bị khóa";
        public const int ERROR_LOGIN_CHANGE_PASS = 4;
        public const string MESSAGE_LOGIN_CHANGE_PASS = "Bạn đã thay đổi mật khẩu vui lòng nhập mật khẩu mới!";
        public const int ERROR_LOGIN_FAIL_PASS = 5;
        public const string MESSAGE_LOGIN_FAIL_PASS = "Sai mật khẩu vui lòng nhập lại mật khẩu";

        public const int ERROR_PHONE_NOT_REGISTER = 1;
        public const string MESSAGE_PHONE_NOT_REGISTER = "Số điện thoại chưa được đăng ký";

        // Register
        public const int ERROR_REGISTER_FIELDS_INVALID = 1;
        public const string MESSAGE_REGISTER_FIELDS_INVALID = "Vui lòng nhập đầy đủ thông tin bắt buộc";
        public const int ERROR_REGISTER_PHONE_INVALID = 2;
        public const string MESSAGE_REGISTER_PHONE_INVALID = "Số điện thoại không đúng định dạng";
        public const int ERROR_REGISTER_PHONE_EXIST = 3;
        public const string MESSAGE_REGISTER_PHONE_EXIST = "Số điện thoại đã tồn tại";
        public const int ERROR_REGISTER_EMAIL_INVALID = 4;
        public const string MESSAGE_REGISTER_EMAIL_INVALID = "Email không đúng định dạng";
        public const int ERROR_REGISTER_EMAIL_EXIST = 5;
        public const string MESSAGE_REGISTER_EMAIL_EXIST = "Email đã tồn tại";
        public const int ERROR_OTP_TRY_EXCEED = 6;
        public const string MESSAGE_OTP_TRY_EXCEED = "Bạn đã vượt quá số lần gửi lại mã OTP , xin vui lòng thử lại sau 5 phút";
        public const int ERROR_PHONE_NOT_EXIST = 7;
        public const string MESSAGE_PHONE_NOT_EXIST = "Số điện thoại không tồn tại";
        public const int ERROR_PHONE_NOT_OTP = 8;
        public const string MESSAGE_PHONE_NOT_OTP = "Mã OTP không hợp lệ";
        public const int ERROR_PHONE_OTP_EXPIRED = 9;
        public const string MESSAGE_PHONE_OTP_EXPIRED = "Mã OTP đã hết hạn";

        // Upload File
        public const int ERROR_FILE_NOT_FOUND = 1;
        public const string MESSAGE_FILE_NOT_FOUND = "Không tìm thấy ảnh tải lên ";

        // Password
        public const int ERROR_CODE_CUSOTMER_LOCK = 1;
        public const string MESSAGE_LOCK_CUSTOMER = "Tài khoản khách hàng đang bị khóa";
        public const string MESSAGE_NOT_CONFIRM_OTP = "Vui Lòng xác nhận OTP trước khi đổi MK";
        public const int CODE_NOT_CONFIRM_OTP = 2;
        public const int ERROR_CUSOTMER_NOT_EXSIST = 1;
        public const string MESSAGE_CUSOTMER_NOT_EXSIST = "Khách hàng không tồn tại";
        public const int ERROR_CHECK_PASSWORD_NOT_EXSIST = 3;
        public const string MESSAGE_CHECK_PASSWORD_NOT_EXSIST = "Mật khẩu không đúng";

        // User
        public const int ERROR_USER_NOT_FOUND = 1;
        public const string MESSAGE_USER_NOT_FOUND = "Tài khoản không tồn tại";
        public const int ERROR_USER_ALREADY_EXIST = 2;
        public const string MESSAGE_USER_ALREADY_EXIST = "Tài khoản đã tồn tại";
        public const int ERROR_USERNAME_ALREADY_EXIST = 3;
        public const string MESSAGE_USERNAME_ALREADY_EXIST = "Tên đăng nhập đã tồn tại";

        public const int ERROR_CHANGE_PASSWORD_WRONG = -1;
        public const string MESSAGE_CHANGE_PASSWORD_WRONG = "Mật khẩu cũ không đúng";

        // Role
        public const int ERROR_ROLE_NOT_FOUND = 1;
        public const string MESSAGE_ROLE_NOT_FOUND = "Phân quyền không tồn tại";
        public const int ERROR_ROLE_NAME_ALREADY_EXIST = 2;
        public const string MESSAGE_ROLE_NAME_ALREADY_EXIST = "Tên phân quyền đã tồn tại";
        public const int ERROR_ROLE_USER_STILL_EXIST = 3;
        public const string MESSAGE_ROLE_USER_STILL_EXIST = "Không thể xóa phân quyền khi vẫn tồn tại tài khoản thuộc phân quyền";



        //Content
        public const int ERROR_CONTENT_NOT_FOUND = 1;
        public const string MESSAGE_CONTENT_NOT_FOUND = "Nội dung này không tồn tại";
        public const int ERROR_CONTENT_ALREADY_EXIST = 2;
        public const string MESSAGE_CONTENT_ALREADY_EXIST = "Nội dung này đã tồn tại";
        public const int TYPE_CONTENT_BANNER = 1;
        public const string MESSAGE_CONTENT_BANNER = "Banner";
        public const int TYPE_CONTENT_FOOTER = 2;
        public const string MESSAGE_CONTENT_FOOTER = "Footer";
        public const int TYPE_CONTENT_CONTACT= 3;
        public const string MESSAGE_CONTENT_CONTACT = "Contact";

        //LevelAdmin
        public const int UserWebAmin = 1;


        public const string ADMIN = "Admin";

        public const bool IS_DELETE = true;
        #endregion
    }
}
