﻿using System.Collections.Generic;

namespace ComponentUtil.Common.Data
{
    public class PageData<T>
    {
        /// <summary>
        ///     当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        ///     集合总数
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        ///     每页项数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     集合
        /// </summary>
        public IList<T> LsList { get; set; }
    }
}