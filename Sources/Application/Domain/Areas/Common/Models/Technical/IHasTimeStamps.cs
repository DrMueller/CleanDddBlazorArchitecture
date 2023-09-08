﻿using System.Diagnostics.CodeAnalysis;

namespace Mmu.CleanBlazor.Domain.Areas.Common.Models.Technical
{
    [SuppressMessage("Design", "CA1044:Properties should not be write only", Justification = "Technical field only, to be used by Unit of Work")]
    public interface IHasTimeStamps
    {
        public DateTime CreatedDate { set; }
        public DateTime UpdatedDate { set; }
    }
}