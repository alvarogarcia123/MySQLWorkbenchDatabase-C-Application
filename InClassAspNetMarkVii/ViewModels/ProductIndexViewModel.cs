using System;
using System.Collections.Generic;

namespace InClassAspNetMarkVii.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<Models.Product> Products { get; set; }
        public int IdForDeletion { get; set; }

    }
}
