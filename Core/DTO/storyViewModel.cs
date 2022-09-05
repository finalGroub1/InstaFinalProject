using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class storyViewModel
    {
        public User user { get; set; }
        public List<Story> storyList { get; set; }
    }
}
