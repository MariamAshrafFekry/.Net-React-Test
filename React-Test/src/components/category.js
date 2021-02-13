import React from 'react'
import '../styles/category.css'
const CategoryList = (props)=>{
    return (
        <div>
            <ul className="Categories">
            {
                props.categories.map(category =>{
                    return (<li key={category.id}>
                        <label>{category.name}</label>
                    </li>
                )})
            }
            </ul>
        </div>
    );
}
export default CategoryList;