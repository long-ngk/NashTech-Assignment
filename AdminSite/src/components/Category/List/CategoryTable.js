import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "../../../shared-components/ButtonIcon";
import { NotificationManager } from "react-notifications";

import Table, { SortType } from "../../../shared-components/Table";
import Info from "../Info";
import { EDIT_CATEGORY_ID } from "../../../Constants/pages";
import ConfirmModal from "../../../shared-components/ConfirmModal";
import {
  NormalCategoryType,
  NormalCategoryTypeLabel,
  LuxuryCategoryType,
  LuxyryCategoryTypeLabel,
} from "../../../Constants/Category/CategoryConstants";
import { DisableCategoryRequest } from "../services/request";

const columns = [
  { columnName: "id", columnValue: "Id" },
  { columnName: "name", columnValue: "Name" },
  { columnName: "type", columnValue: "Type" },
];

const CategoryTable = ({
  categories,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [categoryDetail, setCategoryDetail] = useState(null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: "",
    message: "",
    isDisable: true,
  });

  const handleShowInfo = (id) => {
    const category = categories?.items.find((item) => item.id === id);

    if (category) {
      setCategoryDetail(category);
      setShowDetail(true);
    }
  };

  const getCategoryTypeName = (id) => {
    return id == LuxuryCategoryType
      ? LuxyryCategoryTypeLabel
      : NormalCategoryTypeLabel;
  };

  const handleShowDisable = async (id) => {
    setDisable({
      id,
      isOpen: true,
      title: "Are you sure",
      message: "Do you want to disable this Category?",
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      id: 0,
      title: "",
      message: "",
      isDisable: true,
    });
  };

  const handleResult = async (result, message) => {
    if (result) {
      handleCloseDisable();
      await fetchData();
      NotificationManager.success(
        `Remove Category Successful`,
        `Remove Successful`,
        2000
      );
    } else {
      setDisable({
        ...disableState,
        title: "Can not disable Category",
        message,
        isDisable: result,
      });
    }
  };

  const handleConfirmDisable = async () => {
    let isSuccess = await DisableCategoryRequest(disableState.id);
    if (isSuccess) {
      await handleResult(true, "");
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id) => {
    const existCategory = categories?.items.find(
      (item) => item.id === Number(id)
    );
    history.push(EDIT_CATEGORY_ID(id), {
      existCategory: existCategory,
    });
  };

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: categories?.currentPage,
          totalPage: categories?.totalPages,
          handleChange: handlePage,
        }}
      >
        {categories &&
          categories?.items?.map((data, index) => (
            <tr
              key={index}
              className=""
              onClick={() => handleShowInfo(data.id)}
            >
              <td>{data.id}</td>
              <td>{data.name}</td>
              <td>{getCategoryTypeName(data.type)}</td>

              <td className="d-flex">
                <ButtonIcon onClick={() => handleEdit(data.id)}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
                <ButtonIcon onClick={() => handleShowDisable(data.id)}>
                  <XCircle className="text-danger mx-2" />
                </ButtonIcon>
              </td>
            </tr>
          ))}
      </Table>
      {categoryDetail && showDetail && (
        <Info category={categoryDetail} handleClose={handleCloseDetail} />
      )}
      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>
          <div className="text-center">{disableState.message}</div>
          {disableState.isDisable && (
            <div className="text-center mt-3">
              <button
                className="btn btn-danger mr-3"
                onClick={handleConfirmDisable}
                type="button"
              >
                Disable
              </button>

              <button
                className="btn btn-outline-secondary"
                onClick={handleCloseDisable}
                type="button"
              >
                Cancel
              </button>
            </div>
          )}
        </div>
      </ConfirmModal>
    </>
  );
};

export default CategoryTable;
