//name: Wonhyuk Cho
//submission code :  1211_2300_L02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_Install_o_tron
{

    class Package :IComparable
    {
        //A public automatic property of type string called Name
        // A private list collection of type string, representing the package dependencies
        // A public manual property, get only, returning the current count of dependencies, called Count
        // A public manual property, get only, returning a string, comprised of all the dependencies,
        public string Name { set; get; }
        private List<string> pkgDependencies = new List<string>();
        public int Count
        {
            get
            {
                return pkgDependencies.Count;
            }
        }
        public string Dependencies
        {
            get
            {
                if (Count > 1)
                {
                    string returning = "";
                    for (int i = 1; i <Count; ++i)
                    {
                        if(i == Count - 1)
                        {

                        returning += $" {pkgDependencies.ElementAt(i)} ";
                        }
                        else
                        {
                            returning += $" {pkgDependencies.ElementAt(i)}, ";
                        }

                    }
                    return returning;
                }
                else
                    return "<none>";
            }
        }
        public Package(string[] name)
        {
            this.Name = name[0];
            this.pkgDependencies = name.Distinct().ToList();
         /*   for(int i=1; i<name.Length; ++i)
            {               
                    pkgDependencies.Add(name[i]);
            }*/
        }
        public Package(string s)
        {
            this.Name = s;
            this.pkgDependencies = null;

        }
        public override bool Equals(object obj)
        {
            if (!(obj is Package p)) return false;
            return this.Name.Equals(p.Name);
        }
        public override int GetHashCode()
        {
            return 1;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Package p)) throw new ArgumentException("Invalid");
            return this.Name.CompareTo(p.Name);
        }
        public static int CompareCount(Package p1, Package p2)
        {
            if (p1 is null && p2 is null) return 0;
            if (p1 is null) return -1;
            if (p2 is null) return 1;

            return p1.Count.CompareTo(p2.Count);
        }
        public static int CompareCountName(Package p1 , Package p2)
        {
            if (p1 is null && p2 is null) return 0;
            if (p1 is null) return -1;
            if (p2 is null) return 1;

            if (p1.Count.Equals(p2.Count)) return p1.Name.CompareTo(p2.Name);

            return p1.Count.CompareTo(p2.Count);

        }
        public List<string> GetDepends()
        {
            List<string> _list = new List<string>(pkgDependencies);
            return _list;
        }
        public void MergePackage(Package p)
        {
            if (!p.Name.Equals(this.Name))
                throw new ArgumentException("Invalid");
         
               this.pkgDependencies.Union(p.pkgDependencies);
                
        }
    }
}
