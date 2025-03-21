
document.addEventListener('DOMContentLoaded', function() {
    const blogPostContainer = document.getElementById("blog-posts")
    const addBtn = document.getElementById("addBtn");
    const blogForm = document.getElementById('blogForm')

    function AddBlog(blog){
        const blogpost = document.createElement('div')
        blogpost.className = 'blog-post';
        blogpost.innerHTML = `
                <h3>${blog.title}</h3>
                <div class="author">${blog.author}</div>
                <div class="description">${blog.description}</div>
                <button onclick="deleteBlog(${blog.id})">Delete</button>
                `   
        blogPostContainer.appendChild(blogpost) 
    }

    addBtn.addEventListener('click', function(){
        const author = document.getElementById('author').value
        const title = document.getElementById('title').value
        const description = document.getElementById('description').value
        
        CreateBlog(author, title, description);
    }) 

    async function fetchBlogs() {
        try{
            const response = await fetch('https://localhost:7043/api/Blogs');
            if(!response.ok){
                throw new Error('failed to fetch blogs')
            }

            const blogs = await response.json()

            blogPostContainer.innerHTML = ''

            for(let i = 0; i < blogs.length; i++){
                AddBlog(blogs[i])
            }
        }catch (er){
            console.error('Error:', er)
            alert('failed to fetch blogs.')
        }
    }

    async function CreateBlog(author, title, description){
        try{
            const response = await fetch('https://localhost:7043/api/Blogs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                },
                body: JSON.stringify({author, title, description}),
            })

            if(!response.ok){
                throw new Error('Failed to create blog')
            }

            fetchBlogs()

            blogForm.reset()

        }catch (er){
            console.error('Error:', er)
            alert('Failed to create blog.')
        }
    }

    window.deleteBlog = async function(Id){
        try{
            const response = await fetch(`https://localhost:7043/api/Blogs/${Id}`, {
                method: 'DELETE',
            })

            if(!response.ok){
                throw new Error('Failed to delete blog')
            }

            fetchBlogs()
        }catch (er){
            console.error('Error:', er)
            alert('Failed to delete blog.')
        }
    }
})



