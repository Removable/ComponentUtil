using System;
using System.Collections.Generic;

namespace ComponentUtil.Common.Data
{
    public class PageData<T>
    {
        public PageData(List<T> pagedData, int totalCount, int pageIndex, int pageSize)
        {
            if (pagedData == null) return;

            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = Convert.ToInt32(Math.Ceiling((double) TotalCount / pageSize));

            ListData = pagedData;
        }

        /// <summary>
        ///     当前页
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        ///     每页项数
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        ///     总页数
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        ///     集合总数
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        ///     数据
        /// </summary>
        public List<T> ListData { get; }
    }
}