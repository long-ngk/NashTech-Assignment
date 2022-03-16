import React, { useEffect, useState } from "react";
import { Redirect, useParams, useLocation } from "react-router";

import CategoryForm from "../CategoryForm";

const UpdateCategoryContainer = () => {
  const [category, setCategory] = useState(undefined);
  const { state } = useLocation();
  const { existCategory } = state; // Read values passed on state

  useEffect(() => {
    if (existCategory) {
      setCategory({
        id: existCategory.id,
        name: existCategory.name,
        type: existCategory.type,
        imagePath: existCategory.imagePath,
        imageFile: existCategory.imageFile,
      });
    }
  }, [existCategory]);

  return (
    <div className="ml-5">
      <div className="primaryColor text-title intro-x">
        Update Category {existCategory?.name}
      </div>

      <div className="row">
        {category && <CategoryForm initialCategoryForm={category} />}
      </div>
    </div>
  );
};

export default UpdateCategoryContainer;
