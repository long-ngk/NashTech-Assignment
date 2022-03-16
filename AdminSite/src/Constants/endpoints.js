const Endpoints = {
  authorize: "api/authorize",
  me: "api/authorize/me",

  category: "/api/category",
  categoryId: (id) => `api/category/${id}`,
};

export default Endpoints;
