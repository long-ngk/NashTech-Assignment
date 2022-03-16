import React, { lazy } from "react";
import { Route, Switch } from "react-router-dom";

import {
  CREATE_CATEGORY,
  CATEGORY,
  EDIT_CATEGORY,
} from "../../Constants/pages";

const CreateCategory = lazy(() => import("./Create"));
const ListCategory = lazy(() => import("./List"));
const UpdateCategory = lazy(() => import("./Update"));

const Category = () => {
  return (
    <Switch>
      <Route exact path={CATEGORY}>
        <ListCategory />
      </Route>
      <Route exact path={CREATE_CATEGORY}>
        <CreateCategory />
      </Route>
      <Route exact path={EDIT_CATEGORY}>
        <UpdateCategory />
      </Route>
    </Switch>
  );
};

export default Category;
