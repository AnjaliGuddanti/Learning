import React,{useEffect, useState} from 'react';
import {updatePost,editPost} from '../Redux/posts/actions';
import {useSelector,useDispatch} from 'react-redux';
import { useNavigate, useParams } from 'react-router-dom';
import {connect} from 'react-redux';
import '../Styles/AddPosts.css';
function Edit(props) {
    const navigate =useNavigate();
    const [error,setError]=useState("")
    const params=useParams();
    let Id=params.Id
    props.editPostById(Id);
    let [post,setPosts]=useState({
        Title:(props.post.Title),
        Categories:props.post.Categories,
        Content:props.post.Content
    });
    //const {Title,Categories,Content}=posts

    console.log(post.Categories)
    console.log(props.post.Categories)
    const handleSubmit=(event)=>{
        event.preventDefault();
         if(true){
             setError("Please fill all fields");
        }
         else{
            props.updatePost(post);
            setError("");
            navigate('/',{state:{name:'ReactJs'}});
        } 
        console.log(post)
    } 

    const handleInputChange=(e)=>{
        let {Title,value}=e.target
        setPosts({...post,[Title]:value})
    }
    return (
        <div>
             <a href='/'>back to index</a>
        <div className='addBlog'>
           <form>
				<div className='addBlog__details'>
					<h3>Title</h3>
					<input value={post.Title}  type='text'/>
					<h3> Categories</h3>
					<input value={post.Categories} type='text'/>
                    <h3>Content</h3>
					<textarea value={post.Content}  type='text'/><br/>
                    <button className='btn btn-success' onSubmit={handleSubmit}>Update</button>
                    <button className='btn btn-danger m-2' >clear</button>
                     {error && <h3 style={{color:"red"}}>{error}</h3>}
				</div>
			</form> 
        </div>
        </div>
    );
}
const mapStateToProp=state=>{
    return{
        post:state.posts.post
    }
    }
const mapdispatchToProps= dispatch=>{
    return{
        editPostById:Id=>dispatch(editPost(Id)),
        updatePost:post=>dispatch(updatePost(post))
    }
}
export default connect(mapStateToProp,mapdispatchToProps)(Edit);
