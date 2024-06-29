using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member getMemberByEmail(string email, string password) => MemberDAO.Instance.getMemberByEmail(email,password);

        void IMemberRepository.addNew(Member member) => MemberDAO.Instance.addNew(member);

        Member IMemberRepository.getMemberByID(int id) => MemberDAO.Instance.getMemberByID(id);

        IEnumerable<Member> IMemberRepository.getMemberList() => MemberDAO.Instance.getMemberList();

        void IMemberRepository.Remove(Member member) => MemberDAO.Instance.Remove(member);

        void IMemberRepository.Update(Member member) => MemberDAO.Instance.Update(member);
    }
}
