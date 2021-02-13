import React from 'react'
import '../styles/posts.css'
import Moment from 'react-moment'
import CategoryList from './category'
 const Posts = (props)=> {

    return(
        <div>
            <ul id="PostsList">
                {
                    props.posts.map(post => {
                        return <li key={post.id}>
                            <div className="AuthorInfo">
                               <img src={post.author.avatar} alt={post.author.name} />
                               <label>{post.author.name}</label>
                               <Moment className="Time" format="MMMM DD YYYY hh:mm A">
                                    {post.publishDate}
                               </Moment>
                            </div>
                           <div className="Content">
                             <h5 className="Title">{post.title}</h5>
                             <span>{post.summary}</span>
                             <CategoryList categories={post.categories}></CategoryList>
                           </div> 
                        </li>
                    })
                }
                
            </ul>
        </div>

    );
} 
export default Posts;