using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Models
{
    public interface IComplianceRepository
    {
        public IEnumerable<Comments> MyComments(int EId,int RLId);
        public IEnumerable<RL> MyRLs(int EId);

        public void AddComment(string comm, int EId, int RLId);
        
    }
}
