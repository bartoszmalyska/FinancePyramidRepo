using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinancePyramid
{
    [XmlRoot("piramida")]
    public class Pyramid
    {
        [XmlElement("uczestnik")]
        public User root;

        private List<User> userList = new List<User>();



        /* Getters and Setters */

        public List<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        /* List Generator */
        public void CreateList(User root)
        {
            this.userList.Add(root);
            if (root.under != null)
            {
                foreach (User u in root.under)
                {
                    u.Parent = root;
                    u.Level = root.Level + 1;
                    CreateList(u);
                }
            }
            else // leaf
            {
                User parent = root.Parent;
                User child = root;

                parent.LeavesUnder=parent.LeavesUnder+1;

                while (parent != null)
                {
                   parent.LeavesUnder += child.LeavesUnder;
                   child = parent;
                   parent = parent.Parent;
                }
            }
        }

        public User GetUserById(int id)
        {
            return this.userList.FirstOrDefault(User => User.id == id);
        }


        /* Get all nodes above the user */
        public List<User> GetBranchAbove(int id)
        {
            User user = GetUserById(id);
            List<User> usersAbove = new List<User>();

            if (user != null)
            {
                while(user.Parent!=null)
                {
                    usersAbove.Add(user.Parent);
                    user = user.Parent;
                }

                usersAbove.Reverse();
                return usersAbove;
            }

            usersAbove.Add(this.root);
            return usersAbove;
        }

        /* Apply all the transfers made */
        public void ApplyTransfers(Transfers transfers)
        {
            foreach( Transfer t in transfers.transactions )
            {
                int amount = t.amount;
                List<User> branch = GetBranchAbove(t.from);
                User last = this.root;
                
                foreach(User user in branch)
                {
                    int am = (int) Math.Floor((double)amount/2);
                    user.Prov += am;
                    amount -= am;
                    last = user;
                }
                last.Prov += amount;
            }
        }
    }

}