﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGRIBANKHD.DAL
{
    class ErrorMessageDAL
    {
        public static void DataAccessError(){
            MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu!", "Error", MessageBoxButtons.OK);
        }
    }
}
