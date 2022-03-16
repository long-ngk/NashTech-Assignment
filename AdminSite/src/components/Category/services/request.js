import { AxiosResponse } from "axios";
import qs from "qs";

import RequestService from "../../../services/request";
import EndPoints from "../../../Constants/endpoints";

export function createCategoryRequest(categoryForm) {
  const formData = new FormData();

  Object.keys(categoryForm).forEach((key) => {
    formData.append(key, categoryForm[key]);
  });

  return RequestService.axios.post(EndPoints.category, formData);
}

export function getCategoriesRequest(query) {
  return RequestService.axios.get(EndPoints.category, {
    params: query,
    paramsSerializer: (params) => qs.stringify(params),
  });
}

export function UpdateCategoryRequest(categoryForm) {
  const formData = new FormData();

  Object.keys(categoryForm).forEach((key) => {
    formData.append(key, categoryForm[key]);
  });

  return RequestService.axios.put(
    EndPoints.categoryId(categoryForm.id ?? -1),
    formData
  );
}

export function DisableCategoryRequest(categoryId) {
  return RequestService.axios.delete(EndPoints.categoryId(categoryId));
}
