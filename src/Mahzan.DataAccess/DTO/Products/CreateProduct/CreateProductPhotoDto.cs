﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Products.CreateProduct
{
    public class CreateProductPhotoDto
    {
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }
    }
}
