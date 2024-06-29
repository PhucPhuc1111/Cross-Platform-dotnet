using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }

            }
        }
        public IEnumerable<Member> getMemberList()
        {
            List<Member> members;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    members = MySale.Members.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;

        }

        public Member getMemberByID(int memberID)
        {
            Member members = null;
            try
            {
                using (var MySale = new Sale_ManagementContext())
                {
                    members = MySale.Members.SingleOrDefault(member => member.MemberId == memberID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }
        public Member getMemberByEmail(string email,string password)
        {
            Member members = null;
            try
            {
                using (var MySale = new Sale_ManagementContext())
                {
                    members = MySale.Members.SingleOrDefault(member => member.Email.Equals(email) && member.Password.Equals(password));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }
        public void addNew(Member member)
        {
            try
            {
                Member p = getMemberByID(member.MemberId);
                if (p == null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Members.Add(member);
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The member is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(Member member)
        {
            try
            {
                Member p = getMemberByID(member.MemberId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Entry<Member>(member).State = EntityState.Modified;
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Remove(Member member)
        {
            try
            {
                Member p = getMemberByID(member.MemberId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Members.Remove(member);
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The member does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
