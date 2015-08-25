//using System;
//using System.Collections.Generic;
//using System.Linq;
//using NUnit.Framework;

//namespace AE.HackerRank.Samples.Tests
//{
//    [TestFixture]
//    public class CoursePopularityTest
//    {
//        [TestCase("A", "CSC1")]
//        public void Should(string iuser, string expectedRecomdedCourses)
//        {
//            //Arrange
//            ICourseRecommender sut = new CourseRecommender();

//            var actual = sut.GetRecommendedCourse(iuser);

//            Assert.AreEqual(expectedRecomdedCourses, actual);
//        }
//    }

//    public interface ICourseRecommender
//    {
//        List<string> GetRecommendedCourse(string user);
//    }

//    public class CourseRecommender : ICourseRecommender
//    {
//        /// <summary>
//        /// Gets Recommended ranked courses for a user
//        /// </summary>
//        /// <param name="user">User name</param>
//        /// <returns>a list of recommnded courses ordered by popularity </returns>
//        public List<string> GetRecommendedCourse(string user)
//        {
//            var myattendedCourses = getAttendedCoursesForUser(user);

//            var applicableFriendsList = GetApplicableFriendsForUser(user);
//            var coursesWithPopularity = GetCoursesWithPopularity(applicableFriendsList);
//            var rankedCourseList = coursesWithPopularity.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

//            return rankedCourseList.Where(x => !myattendedCourses.Contains(x)).ToList();
//        }

//        /// <summary>
//        /// Caculates course popularity among friends
//        /// </summary>
//        /// <param name="applicableFriendsList">Friends list</param>
//        /// <returns>returns a dictionary of courses along with popularity</returns>
//        private Dictionary<string, int> GetCoursesWithPopularity(List<string> applicableFriendsList)
//        {
//            var coursePopularity = new Dictionary<string, int>();

//            foreach (var friend in applicableFriendsList)
//            {
//                var courseList = getAttendedCoursesForUser(friend);
//                foreach (var course in courseList)
//                {
//                    if (coursePopularity.ContainsKey(course)) coursePopularity[course] = coursePopularity[course] + 1;
//                    else
//                    {
//                        coursePopularity.Add(course, 1);
//                    }
//                }
//            }
//            return coursePopularity;
//        }

//        /// <summary>
//        /// Gets upto level 2 friends given user
//        /// </summary>
//        /// <param name="user">user name</param>
//        /// <returns>A list of direct and friends of direct friends </returns>
//        private List<string> GetApplicableFriendsForUser(string user)
//        {
//            //Level 1 friend
//            var directFriends = getDirectFriendsForUser(user);
//            var applicableFriendsList = new HashSet<string>(directFriends);

//            //Level 2 friends
//            foreach (var directFriend in directFriends)
//            {
//                var freinds = getDirectFriendsForUser(directFriend);
//                foreach (var friend in freinds)
//                {
//                    //Ensure friends are not duplicated..
//                    if (!applicableFriendsList.Contains(friend)) applicableFriendsList.Add(friend);
//                }
//            }

//            //Result
//            return applicableFriendsList.ToList();
//        }

//        private List<string> getAttendedCoursesForUser(string user)
//        {
//            throw new NotImplementedException();
//        }

//        private List<string> getDirectFriendsForUser(string user)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}