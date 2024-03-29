﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO._Base
{
    public class BaseDto
    {
        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
