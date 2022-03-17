const categoryDropdownList = document.querySelector(
  ".header__navbar-dropdown-content ul"
);

categoryDropdownList.innerHTML = `
    <li>
         <a href="/Home/Category">All</a>
    </li>
`;
fetch("/Home/GetCategory")
  .then((response) => response.json())
  .then((data) => {
    if (data != null) {
      var categories = data.map(
        (item) =>
          ` <li>
            <a href="/Home/Category?categoryID=${item.CategoryID}">${item.CategoryName}</a>
        </li>`
      );
      categoryDropdownList.innerHTML += categories.join("");
    }
  });
