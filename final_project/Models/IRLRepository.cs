using final_project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public interface IRLRepository
    {
        IEnumerable<RL> GetRL();
        void AddRL(RLView rl);
        void DeleteRL(RLView rl);
        void Edit(RLView rl);
        
    }
}
