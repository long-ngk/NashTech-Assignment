import React, { useState } from "react";

import CategoryFormContainer from "../CategoryForm";

const CreateCategoryContainer = () => {
  return (
    <div className="ml-5">
      <div className="primaryColor text-title intro-x">Create New Category</div>

      <div className="row">
        <CategoryFormContainer />
      </div>
    </div>
  );
};

export default CreateCategoryContainer;
