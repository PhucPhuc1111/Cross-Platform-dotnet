using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> getMemberList();
        Member getMemberByID(int id);
        void addNew(Member member);
        void Update(Member member);
        void Remove(Member member);
        Member getMemberByEmail(string email,string password);
    }
}
