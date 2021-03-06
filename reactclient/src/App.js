
import React, { useState } from "react";
import Constants from "./utilities/Constants";
import PostCreateForm from "./components/PostCreateForm";

export default function App() {
  const [posts, setPosts] = useState([]);
  const [showingCreateNewPostForm, setShowingCreateNewPostForm] = useState(false);

  function getPosts() {

    const url = Constants.API_URL_GET_ALL_POSTS;
    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(postsFromServer => {
        setPosts(postsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);

      });

  }
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {showingCreateNewPostForm === false && (
            
            <div >
              <h1> ASP.NET Core React Tutorial</h1>
              <div className="nt-5">
                <button onClick={getPosts} class="btn btn-dark btn-lg w-100">Get Posts from server</button>
                <button onClick={() => setShowingCreateNewPostForm(true)} className="btn btn-secondary btn-lg w-100 m-4">Create New Post</button>

              </div>
            </div>
          )}


          {(posts.length > 0 && showingCreateNewPostForm === false) && renderPostsTable()}

          {showingCreateNewPostForm && <PostCreateForm onPostCreated={onPostCreated} />}
        </div>
      </div>
    </div>
  );

  function renderPostsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">PostId (PK)</th>
              <th scope="col">Title </th>
              <th scope="col">Content </th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {posts.map((post) =>
            (<tr key={post.postId}>
              <th scope="row">{post.postId}</th>
              <td>{post.title}</td>
              <td>{post.content}</td>
              <td>
                <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                <button className="btn btn-secondary btn-lg">Delete</button>
              </td>
            </tr>))}
          </tbody>
        </table>
        <button onClick={() => setPosts([])} className="btn btn-dark btn-lg w-100">Empty React posts array</button>
      </div>
    );
  }

  function onPostCreated(createdPost) {
    setShowingCreateNewPostForm(false);
    if (createdPost === null) {
      return;
    }
    alert(`Post succesfully created. After clicking Ok, your new post titled "${createdPost.title}" will show up in the table below.`);

    getPosts();
  }
}

