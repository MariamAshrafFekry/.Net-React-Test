import React , {useState} from 'react'
import '../styles/layout.css'
import Posts from './posts'
const Layout = ()=>{
    const [posts,setPosts]=useState([]);
    const [tempPosts,setTempPosts]=useState([]);
    const [pageNumber , loadMore] = useState(1);
    window.onload = function(){
        fetch("/api/posts")
        .then(response=>{
            if(!response.ok){
                alert("error");
            }
            else{
                var allPosts = JSON.parse(response._bodyText);
                setPosts(allPosts.posts);
                console.log(allPosts);
                document.getElementById("linkLoadMore").click();
            }
        })
    }
    const onClickLoadMore = ()=>{
        var postsCount = Math.ceil(parseInt(posts.length)/3.0);
        if(postsCount >= parseInt(pageNumber)){
            var to = (parseInt(pageNumber))*3;
            setTempPosts(
                posts.slice(0 , to)
            )
            loadMore(parseInt(pageNumber) + 1);
        }
    }
    return (
        <div>
            <Posts posts={tempPosts} />
            <center>
                  <button onClick={onClickLoadMore} id="linkLoadMore">load more..</button>
            </center>
          
        </div>
    )
}
export default Layout;