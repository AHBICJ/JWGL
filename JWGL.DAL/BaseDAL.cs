using System;
using System.Collections.Generic;
using JWGL.Model;
namespace JWGL.DAL
{
	/// <summary>
	/// 继承自Person的类都使用这个DAL。
	/// </summary>
	[Serializable]
	public class BaseDAL
	{
		private List<Person> persons;

		public BaseDAL()
		{
            persons = new List<Person>();
		}

		/// <summary>
		/// 增加
		/// </summary>
		/// <param name="person"></param>
		/// <returns></returns>
		public bool Add(Person person)
		{
			for(int i=0;i<persons.Count;i++)
			{
				if(person.ID ==persons[i].ID)
				{
					return false;
				}
			}
			persons.Add(person);
			return true;
		}

		/// <summary>
		/// 根据ID删除
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public bool Remove(string ID)
		{
			for(int i=0;i<persons.Count;i++)
			{
				if(ID == persons[i].ID)
				{
					persons.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 根据ID查询
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public Person Retrieve(string ID)
		{
			for(int i=0;i<persons.Count;i++)
			{
                if (ID == persons[i].ID)
				{
					return persons[i];
				}
			}
			return null;
		}
        public bool ChangPW(Person p,string newPw)
        {
            Person thePerson = Retrieve(p.ID);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
        public bool ChangPW(string pid, string newPw)
        {
            Person thePerson = Retrieve(pid);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
		public Person[] RetrieveAll()
		{
			return persons.ToArray();
		}
	

	}
}
