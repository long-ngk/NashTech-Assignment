import React from "react";
import { CaretDownFill, CaretUpFill } from "react-bootstrap-icons";

import Paging, { PageType } from "./Paging";
import "./Table.css";

const ColumnIcon = ({ colValue, sortState }) => {
  if (colValue === sortState.columnValue) {
    if (sortState.orderBy === 'Decsending') {
      return <CaretDownFill />
    }
    else {
      return <CaretUpFill />
    }
  } 

  return (<CaretDownFill />);
};

const Table = ({ columns, children, page, sortState, handleSort }) => {

  return (
    <>
      <div className="table-container">
        <table className="table">
          <thead>
            <tr>
              {
                columns.map((col, i) => (
                  <th key={i}>
                    <a className="btn" onClick={() => handleSort(col.columnValue)}>
                      {col.columnName}
                      <ColumnIcon colValue={col.columnValue} sortState={sortState} />
                    </a>
                  </th>
                ))
              }
            </tr>
          </thead>

          <tbody>{children}</tbody>
        </table>
      </div>
      {
        (page && page.totalPage && page.totalPage > 1) && <Paging {...page} />
      }
    </>
  );
};

export default Table;
