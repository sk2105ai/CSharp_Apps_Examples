using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Examples
{
    /// <summary>
    /// This class contains the method for polymorphism examples
    /// </summary>
    /// <CreatedBy>Shahir Khan</CreatedBy>
    /// <CreatedDate>May 05,2025</CreatedDate>
    internal class clsExamplePolymorphism
    {
        /// <summary>
        /// This method will return sum of two numbers
        /// </summary>
        /// <param name="FirstNum">int</param>
        /// <param name="SecondNum">int</param>
        /// <returns>int</returns>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 05,2025</CreatedDate>
        public int Add(int FirstNum, int SecondNum)
        {
            int sum = 0;
            try
            {
                sum = FirstNum + SecondNum;
                return sum;
            }
            catch (Exception ex)
            {
                //log error message here
                Console.WriteLine("We have encountered error in processing the add reuqest of two numbers: "+ex.Message.ToString());
                return sum;
            }
        }

        /// <summary>
        /// This method will return sum of two numbers
        /// </summary>
        /// <param name="FirstNum">int</param>
        /// <param name="SecondNum">int</param>
        /// <returns>int</returns>
        /// <CreatedBy>Shahir Khan</CreatedBy>
        /// <CreatedDate>May 05,2025</CreatedDate>
        public int Add(int FirstNum, int SecondNum, int ThirdNum)
        {
            int sum = 0;
            try
            {
                sum = FirstNum + SecondNum + ThirdNum;
                return sum;
            }
            catch (Exception ex)
            {
                //log error message here
                Console.WriteLine("We have encountered error in processing the add reuqest of three numbers: " + ex.Message.ToString());
                return sum;
            }
        }
    }
}
