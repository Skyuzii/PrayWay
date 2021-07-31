﻿using System.Collections.Generic;

namespace PrayWay.Application.Common.Dto
{
    public class QueryResultDto<TResult>
    {
        /// <summary>
        /// Общее количество записей, попадающих под условия запроса
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// Записи, попадающие под условия запроса
        /// </summary>
        public IList<TResult> Items { get; set; }

    }
}