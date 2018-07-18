using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public interface IForumRepository
    {
        IEnumerable<Forum> GetAllForums();
        Forum GetForumByID(int ForumID);

        IEnumerable<Thread> GetAllThreads();
        IEnumerable<Post> GetAllPosts();

        IEnumerable<Thread> GetThreadsByForum(int ForumID);
        IEnumerable<Post> GetPostsByThread(int ThreadID);

        Thread GetThreadByID(int ThreadID);
        Post GetPostByID(int PostID);

        void AddForum(Forum forum);
        void AddThread(Thread thread);
        void AddPost(Post post);
        void UpdateForum(Forum forum);
        void UpdateThread(Thread thread);
        void UpdatePost(Post post);
        void DeleteForum(Forum forum);
        void DeleteThread(Thread thread);
        void DeletePost(Post post);


    }
}
