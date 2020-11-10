using System;
using System.Collections.Generic;
using System.Linq;

namespace ComponentUtil.Common.Data
{
    public record PageData<T>
    {
        public PageData(List<T> pagedData, int totalCount, int pageIndex, int pageSize)
        {
            if (pagedData == null) return;

            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = Convert.ToInt32(Math.Ceiling((double) TotalCount / pageSize));

            PagedData = pagedData;
        }

        public PageData(List<T> listData, int pageIndex, int pageSize)
        {
            if (listData == null) listData = new List<T>();

            TotalCount = listData.Count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = Convert.ToInt32(Math.Ceiling((double) listData.Count / pageSize));

            PagedData = listData.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
        public List<T> PagedData { get; }
    }
}