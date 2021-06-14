<template>
  <div class="content-area__content">
    <div class="body body-di">
      <!-- Phần thêm nhà cung cấp  -->
      <div class="title-distance lock-title-distance">
        <div class="header-di">
          <div class="title-di">Danh sách nhà cung cấp</div>
          <div class="header-di">
            <div class="header-button">
              <div class="guide-tour">
                <div class="mi mi-24 mi-tour"></div>
                <div class="tour-label">Hướng dẫn</div>
              </div>
              <div class="dropdown-secondary mr-12-px ms-dropdown">
                <dropdown-button>
                  <template slot="dropdown-button">
                    <button
                      name="button"
                      class="
                        ms-component
                        ms-button
                        ms-button-secondary
                        ms-con-dropdown-radius-true-true
                        ms-padding-is-single-true-size-default
                        expand-more-button
                        ms-button-size-default
                      "
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        <span class="pr-1">Tiện ích</span>
                        <div class="mi mi-16 mi-arrow-up--black">&nbsp;</div>
                      </div>
                    </button>
                  </template>
                  <template slot="dropdown-list">
                    <div
                      class="
                        ms-component ms-dropdown-item-secondary-false
                        ms-dropdown--item
                      "
                    >
                      <a class="ms-dropdown--item-link"
                        >Gộp nhà cung cấp tự động
                      </a>
                    </div>
                  </template>
                </dropdown-button>
              </div>

              <div class="add-btn ms-dropdown">
                <button
                  name="button"
                  class="
                    ms-component
                    ms-button
                    ms-button-size-default
                    ms-button-primary
                    ms-radius-true
                    ms-dropdown-style-default
                  "
                  @click="
                    showPopup(),
                      setIsEditFalse(),
                      setIsReadOnlyFalse(),
                      (idSupplier = '')
                  "
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Thêm
                  </div>
                </button>
                <dropdown-button>
                  <template slot="dropdown-button">
                    <button
                      name="button"
                      class="
                        ms-component
                        ms-button
                        ms-padding-is-single-false-size-default
                        ms-con-dropdown-radius-false-true
                        ms-padding-is-single-false-size-default
                        ms-button-primary
                      "
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        <div class="line"></div>
                        <div class="mi mi-16 mi-arrow-up--white bg-green">
                          &nbsp;
                        </div>
                      </div>
                    </button>
                  </template>
                  <template slot="dropdown-list">
                    <div
                      class="
                        ms-component ms-dropdown-item-secondary-false
                        ms-dropdown--item
                      "
                    >
                      <a class="ms-dropdown--item-link">Nhập từ Excel </a>
                    </div>
                  </template>
                </dropdown-button>
              </div>
            </div>
          </div>
        </div>
        <div class="back flex justify back-all-di">
          <div class="mi mi-16 mi-chevron-left--primary"></div>
          <a href="#">Tất cả danh mục</a>
        </div>
      </div>

      <!-- Filter  -->
      <div class="sticky overview left-0">
        <div class="inner-overview flex">
          <div class="w-1/3 pd-t-8 over-view">
            <div class="dued-debit-overview mouse-poiter">
              <div
                class="dued-debit-overview-data inner-overview-data"
                style="position: relative"
              >
                <div class="mi funnel-icon"></div>
                <div class="overview-data-number flex">
                  <div class="total-money">0,00</div>
                </div>
                <div class="label-overview">Nợ quá hạn</div>
              </div>
              <div class="over-view-line"></div>
            </div>
          </div>

          <div class="w-1/3 px-2 pd-t-8 over-view">
            <div class="total-debit-overview mouse-poiter">
              <div
                class="dued-debit-overview-data inner-overview-data"
                style="position: relative"
              >
                <div class="mi funnel-icon"></div>
                <div class="overview-data-number flex">
                  <div class="total-money">1.234.567,89</div>
                </div>
                <div class="label-overview">Tổng nợ phải trả</div>
              </div>
              <div class="over-view-line"></div>
            </div>
          </div>

          <div class="w-1/3 pd-t-8">
            <div class="payment-overview">
              <div
                class="payment-overview-data inner-overview-data"
                style="position: relative"
              >
                <div class="mi funnel-icon"></div>
                <div class="overview-data-number flex">
                  <div class="total-money">1.000.000,00</div>
                </div>
                <div class="label-overview">
                  Đã thanh toán (30 ngày gần đây)
                </div>
              </div>
              <div class="over-view-line"></div>
            </div>
          </div>
        </div>
      </div>

      <!-- Lọc và tìm kiếm -->
      <div class="grid-list-data sticky left-0">
        <div class="grid-button-list">
          <div class="flex">
            <div class="check-all-arrow">
              <div class="mi mi-24 mi-arrow-check-all"></div>
            </div>
            <div class="flex-grow inline">
              <div id="check-all-dropdown">
                <div class="dropdown-secondary px ms-dropdown">
                  <dropdown-button>
                    <template slot="dropdown-button">
                      <button
                        name="button"
                        class="
                          ms-component
                          ms-button
                          ms-button-secondary
                          ms-con-dropdown-radius-true-true
                          ms-padding-is-single-true-size-default
                          expand-more-button
                          ms-button-size-default
                        "
                      >
                        <div
                          class="
                            ms-button-text
                            ms-button--text
                            flex
                            align-center
                          "
                        >
                          <span class="pr-1">Thực hiện hàng loạt</span>
                          <div class="mi mi-16 mi-arrow-up--black">&nbsp;</div>
                        </div>
                      </button>
                    </template>
                    <template slot="dropdown-list">
                      <div
                        class="
                          ms-component ms-dropdown-item-secondary-false
                          ms-dropdown--item
                        "
                      >
                        <a class="ms-dropdown--item-link">Xóa </a>
                      </div>
                      <div
                        class="
                          ms-component ms-dropdown-item-secondary-false
                          ms-dropdown--item
                        "
                      >
                        <a class="ms-dropdown--item-link">Gộp </a>
                      </div>
                    </template>
                  </dropdown-button>
                </div>
              </div>

              <div id="filter-dropdown">
                <div class="dropdown-secondary px ms-dropdown">
                  <dropdown-button>
                    <template slot="dropdown-button">
                      <button
                        name="button"
                        class="
                          ms-component
                          ms-button
                          ms-button-secondary
                          ms-con-dropdown-radius-true-true
                          ms-padding-is-single-true-size-default
                          expand-more-button
                          ms-button-size-default
                        "
                      >
                        <div
                          class="
                            ms-button-text
                            ms-button--text
                            flex
                            align-center
                          "
                        >
                          <span class="pr-1">Lọc</span>
                          <div class="mi mi-16 mi-arrow-up--black">&nbsp;</div>
                        </div>
                      </button>
                    </template>
                    <template slot="dropdown-list">
                      <div>Form Filter</div>
                    </template>
                  </dropdown-button>
                </div>
              </div>
            </div>

            <div class="flex search-wrapper">
              <div class="ms-input">
                <input
                  id="input-search-supplier"
                  class="input-search hasIcon"
                  type="text"
                  placeholder="Nhập từ khóa tìm kiếm"
                />
                <label
                  class="
                    icon-inputx
                    notranslate
                    ms-input--icon
                    icon-after
                    mi-search mi mi-16
                  "
                  for="input-search-supplier"
                ></label>
              </div>
            </div>

            <div class="flex">
              <div class="ultility-buttons flex">
                <div class="refresh-button list-button" title="Làm mới bộ lọc">
                  <div class="mi mi-24 mi-refresh"></div>
                </div>
                <div class="print-button list-button" title="Nhập từ Excel">
                  <div class="mi mi-24 mi-excel__nav"></div>
                </div>
                <div class="setting-button list-button" title="Cài đặt">
                  <div class="mi mi-24 mi-setting__list"></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="collapse-overview flex items-center justify-center">
          <div class="mi mi-16 mi-chevron-up--primary"></div>
        </div>
      </div>

      <!-- Bảng -->
      <div class="grid flex bg-white">
        <div class="grid-model-control">
          <div class="ms-grid-viewer table-scroll table-area" outsize="30px">
            <table v-show="!loading" class="ms-table-viewer">
              <thead class="ms-thead-viewer">
                <tr class="ms-tr-viewer">
                  <th class="ms-out-left-white-16"></th>
                  <th class="ms-th-viewer ms-muli-checkall" style="left: 16px">
                    <check-box></check-box>
                  </th>
                  <div class="dis-contents ms-tbody-viewer">
                    <th class="ms-th-viewer dymamic-col header w-180">
                      <span class="ms-head-title flex justify-left"
                        >Mã nhà cung cấp
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Tên nhà cung cấp
                        <!-- <div class="mi mi-16" style="display: none"></div> -->
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Địa chỉ
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Mã số thuế
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-150">
                      <span class="ms-head-title flex justify-left"
                        >CMTND
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-180">
                      <span class="ms-head-title flex justify-left"
                        >Trạng thái
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>
                  </div>
                  <th
                    class="ms-th-viewer ms-th-wiget"
                    style="right: 30px; width: 120px; min-width: 120px"
                  >
                    <span class="ms-head-title float-right">Chức năng</span>
                  </th>
                  <th class="ms-out-right-white-30"></th>
                  <th class="ms-out-right-grey-30"></th>
                </tr>
              </thead>

              <tbody class="dis-contents ms-tbody-viewer">
                <tr
                  class="ms-tr-viewer"
                  v-for="supplier in suppliers"
                  :key="supplier.idsupplier"
                  :idsupplier="supplier.idsupplier"
                >
                  <td class="ms-out-left-white-16"></td>
                  <td class="ms-td-viewer ms-td-multi" style="left: 16px">
                    <check-box></check-box>
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ supplier.suppliercode }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ supplier.suppliername }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ supplier.supplieraddress }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ supplier.suppliertaxcode }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ supplier.identitycardnumber }}
                  </td>
                  <td class="ms-td-viewer text-left">Đang sử dụng</td>
                  <td class="ms-td-viewer ms-td-wiget text-right">
                    <div class="flex justify-end">
                      <div class="ms-dropdown">
                        <button
                          class="ms-button edit-btn"
                          @click="
                            showPopup(),
                              setIsEditTrue(),
                              setIsReadOnlyFalse(),
                              (idSupplier = supplier.idsupplier)
                          "
                        >
                          <div class="ms-button-text flex align-center">
                            Sửa
                          </div>
                        </button>
                        <dropdown-button>
                          <template slot="dropdown-button">
                            <button class="ms-button function-btn">
                              <div class="ms-button-text flex align-center">
                                <div class="mi mi-16 mi-arrow-up--blue">
                                  &nbsp;
                                </div>
                              </div>
                            </button>
                          </template>
                          <template slot="dropdown-list">
                            <div
                              class="
                                ms-component ms-dropdown-item-secondary-false
                                ms-dropdown--item
                              "
                            >
                              <a
                                class="ms-dropdown--item-link"
                                @click="
                                  (idSupplierDelete = supplier.idsupplier),
                                    showDeleteDialog(supplier.suppliercode)
                                "
                                >Xóa
                              </a>
                            </div>
                            <div
                              class="
                                ms-component ms-dropdown-item-secondary-false
                                ms-dropdown--item
                              "
                            >
                              <a
                                class="ms-dropdown--item-link"
                                @click="
                                  showPopup(),
                                    setIsReadOnlyTrue(),
                                    (idSupplier = supplier.idsupplier)
                                "
                                >Xem
                              </a>
                            </div>
                          </template>
                        </dropdown-button>
                      </div>
                    </div>
                  </td>
                  <td class="ms-out-right-white-30"></td>
                  <td class="ms-out-right-grey-30"></td>
                </tr>
                <!-- <tr class="ms-tr-viewer">
                <td class="ms-out-left-white-16"></td>
                <td class="ms-td-viewer text-left">NV0001</td>
                <td class="ms-td-viewer text-left">Nguyễn Kiên Trung</td>
                <td class="ms-td-viewer text-left">Giám đốc</td>
                <td class="ms-td-viewer text-left">Ban giám đốc</td>
                <td class="ms-td-viewer text-left">10847232699636</td>
                <td class="ms-td-viewer text-left">
                  Ngân hàng Nông nghiệp và Phát triển nông thôn Việt Nam
                </td>
                <td class="ms-td-viewer text-left">Chi nhánh Hai Bà Trưng</td>
                <td class="ms-td-viewer text-left">Đang sử dụng</td>
                <td class="ms-td-viewer ms-td-wiget text-right">
                  <div class="flex justify-end">
                    <div class="ms-dropdown">
                      <button
                        class="ms-button edit-btn"
                        data-toggle="modal"
                        data-target="#supplier-dialog"
                      >
                        <div class="ms-button-text flex align-center">Sửa</div>
                      </button>

                      <button class="ms-button function-btn">
                        <div class="ms-button-text flex align-center">
                          <div class="mi mi-16 mi-arrow-up--blue">&nbsp;</div>
                        </div>
                      </button>
                    </div>
                  </div>
                </td>
                <td class="ms-out-right-white-30"></td>
                <td class="ms-out-right-grey-30"></td>
              </tr> -->
              </tbody>
            </table>
            <div
              v-show="loading"
              class="m-3"
              id="spinner-load-data"
              style="display: none !important"
            >
              <div class="d-flex justify-content-center">
                <div
                  class="spinner-border"
                  role="status"
                  style="color: #019160 !important"
                >
                  <span class="sr-only">Loading...</span>
                </div>
              </div>
            </div>
            <div class="ms-pagination">
              <div
                class="flex items-center justify-between w-full pagination-bar"
              >
                <div class="left-pagination">
                  <div class="total-record">
                    Tổng số: <b>{{ suppliers.length }}</b> bản ghi
                  </div>
                </div>
                <div class="flex postion-pagination align-center">
                  <div class="record-in-page">
                    <!-- <div class="ms-combo ms-combo-box">
                      <div class="combo-main-content">
                        <div class="selected-options">
                          <input
                            type="text"
                            size="1"
                            placeholder=""
                            readonly="true"
                            autofocus="autofocus"
                            error="Error"
                            class="combo-input"
                            style="text-align: left"
                            value="10 bản ghi trên 1 trang"
                            id="number-record-in-page"
                          />
                        </div>
                        <div class="combo-actions">
                          <label
                            class="btn-dropdown m-0"
                            id="show-option-record-in-page"
                            for="number-record-in-page"
                          >
                            <div
                              class="mi mi-16 mi-arrow-dropdown arrow-dropdown--close"
                            ></div>
                          </label>
                        </div>
                      </div>
                    </div> -->
                    <ms-select
                      :items="recordInPage"
                      :itemDefault="1"
                    ></ms-select>
                  </div>

                  <div style="display: flex; align-items: center">
                    <div class="mr-3 pointer unselect disableText">Trước</div>
                    <div class="page-index">
                      <div class="pl-2 pr-2 pointer pageSelected">1</div>
                      <div class="pl-2 pr-2 pointer">2</div>
                      <div class="pl-2 pr-2 pointer">3</div>
                      <div class="pl-2 pr-2"></div>
                      <div class="pl-2 pr-2 pointer">...</div>
                      <div class="pl-2 pr-2 pointer">12</div>
                    </div>
                    <div class="ml-3 pointer unselect">Sau</div>
                  </div>
                </div>
              </div>
              <th class="ms-out-right-white-30"></th>
              <th class="ms-out-right-grey-30"></th>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="con-ms-message-box" id="delete-dialog" style="display: none">
      <div class="message-center">
        <div class="ms-message-bg"></div>
        <div class="drag-it-dude">
          <div class="ms-mesage-box">
            <div style="width: 444px; min-width: 444px">
              <div class="padding-32">
                <div class="content">
                  <div class="icon-message">
                    <div class="mi mi-48 mi-exclamation-warning-48"></div>
                  </div>
                  <div class="message-content p-l-16 p-t-12">
                    <span id="idMessageDelete" class="message"></span>
                  </div>
                </div>
                <div class="mess-line"></div>
                <div class="mess-footer">
                  <div class="RightSecond">
                    <button
                      name="button"
                      class="
                        ms-component
                        ms-button
                        ms-button-size-default
                        ms-button-primary
                        ms-button-primary-disabled-false
                        ms-button-radius-false
                        ms-button
                      "
                      @click="deleteSupplier()"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Có
                      </div>
                    </button>
                  </div>

                  <div class="Left">
                    <button
                      name="button"
                      class="
                        ms-component
                        ms-button
                        ms-button-size-default
                        ms-button-secondary
                        ms-button-secondary-disabled-false
                        ms-button-radius-false
                        ms-button
                      "
                      @click="hideDeleteDialog()"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Không
                      </div>
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <add-supplier-dialog
      @closePopup="closePopup"
      @loadData="loadData"
      :isShowPopup="isShowPopup"
      :idSupplier="idSupplier"
    ></add-supplier-dialog>
  </div>
</template>


<script>
var localhost = "https://localhost:44350/api/Suppliers/";

import DropdownButton from "../baseControl/DropdownButton.vue";
import CheckBox from "../baseControl/CheckBox.vue";
import MsSelect from "../baseControl/MsSelect.vue";
// import SelectAutoComplete from "../baseControl/SelectAutoComplete.vue";
import AddSupplierDialog from "../supplier/AddSupplierDialog.vue";
import EventBus from "../../main.js";

import * as axios from "axios";
export default {
  name: "SupplierList",
  components: {
    DropdownButton,
    CheckBox,
    // SelectAutoComplete,
    AddSupplierDialog,
    MsSelect,
  },
  data() {
    return {
      loading: false,
      isShowPopup: false,
      // suppliers: [
      //   {
      //     supplierId: "1",
      //     supplierCode: "123456",
      //     supplierName: "Công ty trách nhiệm hữu hạn KT",
      //     supplierAddress: "Khu ngoại giao đoàn",
      //     supplierDebt: 0,
      //     supplierTaxCode: "123456789",
      //     supplierPhone: "0968866868",
      //     branchName: "Đường Láng",
      //   },
      //   {
      //     supplierId: "2",
      //     supplierCode: "123456",
      //     supplierName: "Công ty trách nhiệm hữu hạn KT",
      //     supplierAddress: "Khu ngoại giao đoàn",
      //     supplierDebt: 0,
      //     supplierTaxCode: "123456789",
      //     supplierPhone: "0968866868",
      //     branchName: "Đường Láng",
      //   },
      //   {
      //     supplierId: "3",
      //     supplierCode: "123456",
      //     supplierName: "Công ty trách nhiệm hữu hạn KT",
      //     supplierAddress: "Khu ngoại giao đoàn",
      //     supplierDebt: 0,
      //     supplierTaxCode: "123456789",
      //     supplierPhone: "0968866868",
      //     branchName: "Đường Láng",
      //   },
      //   {
      //     supplierId: "4",
      //     supplierCode: "123456",
      //     supplierName: "Công ty trách nhiệm hữu hạn KT",
      //     supplierAddress: "Khu ngoại giao đoàn",
      //     supplierDebt: 0,
      //     supplierTaxCode: "123456789",
      //     supplierPhone: "0968866868",
      //     branchName: "Đường Láng",
      //   },
      //   {
      //     supplierId: "5",
      //     supplierCode: "123456",
      //     supplierName: "Công ty trách nhiệm hữu hạn KT",
      //     supplierAddress: "Khu ngoại giao đoàn",
      //     supplierDebt: 0,
      //     supplierTaxCode: "123456789",
      //     supplierPhone: "0968866868",
      //     branchName: "Đường Láng",
      //   },
      // ],
      idSupplier: "",
      idSupplierDelete: "",
      suppliers: [],

      recordInPage: [
        "10 bản ghi trên 1 trang",
        "20 bản ghi trên 1 trang",
        "30 bản ghi trên 1 trang",
        "50 bản ghi trên 1 trang",
        "100 bản ghi trên 1 trang",
      ],
    };
  },
  methods: {
    setWidthForPagination() {
      var width =
        document.getElementsByClassName("ms-table-viewer")[0].offsetWidth;
      console.log(width);
      // document.getElementsByClassName("ms-pagination")[0].style.width =
      //   width + "px";
      document.getElementsByClassName("ms-pagination")[0].style.width =
        "1497px";
    },

    showPopup() {
      this.isShowPopup = true;
    },

    closePopup(value) {
      this.isShowPopup = value;
    },

    setIsEditTrue() {
      EventBus.$emit("setIsEdit", true);
    },

    setIsEditFalse() {
      EventBus.$emit("setIsEdit", false);
    },

    setIsReadOnlyTrue() {
      EventBus.$emit("setIsReadOnly", true);
    },

    setIsReadOnlyFalse() {
      EventBus.$emit("setIsReadOnly", false);
    },

    setIdSupplier(id) {
      this.idSupplier = id;
    },

    showDeleteDialog(suppliercode) {
      console.log(suppliercode);
      document.getElementById("idMessageDelete").innerHTML =
        "Bạn có thực sự muốn xóa Nhà cung cấp < " + suppliercode + " > không?";
      document.getElementById("delete-dialog").style.display = "block";
    },

    hideDeleteDialog() {
      document.getElementById("delete-dialog").style.display = "none";
    },

    async deleteSupplier() {
      let m = this;
      await axios({
        method: "delete",
        url: localhost + this.idSupplierDelete,
      })
        .then(function (response) {
          //thành công
          console.log(response);
          m.hideDeleteDialog();
          //load lại data sau khi xóa
          m.loadData();
        })
        .catch(function (response) {
          //gặp lỗi
          console.log(response);
        });
    },

    async loadData() {
      this.loading = true;
      const response = await axios.get(localhost);

      console.log(response.data);
      this.loading = false;
      this.suppliers = response.data;
      this.setWidthForPagination();

      this.idSupplier = "";
    },
  },
  async created() {
    this.loadData();
  },
  mounted() {
    // this.setWidthForPagination();
  },
};
</script>

<style scoped>
.body {
  padding-right: 30px;
  overflow: scroll;
  height: calc(100vh - 48px);
}
</style>
<style>
.popup-payment .con-ms-popup > .ms-popup-content > .ms-popup--content {
  overflow: visible;
  padding: 0;
}
.body-di {
  max-height: unset !important;
}

.title-distance {
  position: sticky !important;
  left: 0;
  margin: 0;
  padding-top: 22px;
  padding-bottom: 16px;
}

.lock-title-distance {
  position: sticky;
  background: #f4f5f6;
  z-index: 10;
  top: 0;
}

/**Header cho mục Title */
.header-di {
  position: relative;
  display: flex;
  justify-content: space-between;
}

.header-di .title-di {
  font-size: 24px;
  font-weight: 700;
  color: #111;
}

/**Nút back về tất cả danh mục */
.back-all-di {
  cursor: pointer;
  width: -webkit-max-content;
  width: -moz-max-content;
  width: max-content;
}

.back {
  color: #0075c0;
  cursor: pointer;
}

.back a {
  font-size: 13px;
  font-weight: 300;
}

.back a,
.back a:active,
.back a:hover,
.back a:visited {
  color: #0075c0;
  cursor: pointer;
}

/**Phần button trên title */
.header-button {
  display: flex;
}

.guide-tour {
  position: relative;
  margin-right: 10px;
  display: flex;
  align-items: center;
}

.guide-tour .tour-label {
  white-space: nowrap;
  padding-left: 5px;
  font-size: 13px;
  color: #0075c0;
}

.guide-tour .tour-label:hover {
  text-decoration: underline;
  cursor: pointer;
}

/**Button dropdown */
.ms-dropdown {
  display: flex;
}

.ms-button {
  transition: all 0.2s ease;
  border: 0;
  cursor: pointer;
  position: relative;
  overflow: hidden;
  color: #fff;
  box-sizing: border-box;
  background: transparent;
  overflow: visible;
}

.dropdown-secondary .ms-button.ms-button-secondary {
  border: 2px solid #3b3c3f;
}

.dropdown-secondary .ms-component.ms-button {
  padding: 0 16px !important;
}

.ms-button-secondary {
  border: 1px solid #8d9096;
  color: #111;
  background-color: transparent;
}

.ms-button-secondary:hover {
  background-color: #d2d3d6;
}

.ms-button-secondary:active {
  background-color: #bbbcbc;
}

.ms-con-dropdown-radius-true-true {
  border-radius: 30px;
  color: #111;
}

.ms-radius-true,
.ms-radius-true:before {
  border-radius: 30px 0 0 30px;
}

.ms-button-radius-false,
.ms-button-radius-false:before {
  border-radius: 3px;
}

.ms-padding-is-single-true-size-default {
  height: 36px;
  padding: 8px 20px;
}

.ms-dropdown-style-default {
  padding: 8px 14px 8px 20px;
  height: 36px;
}

.expand-more-button {
  height: 100%;
  position: relative;
}

.ms-button-size-default {
  height: 36px;
  padding: 8px 20px;
}

.ms-button .ms-button--text {
  font-weight: 600;
  position: relative;
  color: inherit;
  display: inline-block;
  transition: all 0.25s ease;
  white-space: nowrap;
  font-size: 13px;
  line-height: 13px;
}

.ms-dropdown--item {
  white-space: nowrap;
  transition: all 0.2s ease;
  position: relative;
  z-index: 1000;
  text-align: left;
  width: 100%;
  list-style: none;
  min-width: 100px;
  font-weight: 400 !important;
  font-size: 13px;
}

.ms-dropdown--item:hover {
  background: #e8e9ec;
  color: #111;
}

.ms-dropdown--item .ms-dropdown--item-link {
  background: inherit !important;
  color: inherit !important;
  cursor: pointer;
  transition: all 0.2s ease;
  padding: 5px;
  padding-left: 10px;
  padding-right: 10px;
  width: 100%;
  position: relative;
  display: block;
  color: rgba(0, 0, 0, 0.7);
}

.ms-button-primary {
  border: 1px solid transparent;
  color: #fff;
  background-color: #2ca01c;
}

.ms-button-primary:hover {
  background-color: #35bf22;
  color: #fff;
}

.ms-button-primary:focus {
  background-color: #2ca01c;
  color: #fff;
}

.ms-button-primary:active {
  background-color: #248b15;
  color: #fff;
}

.ms-padding-is-single-false-size-default {
  width: 46px;
}

.ms-con-dropdown-radius-false-true,
.ms-con-dropdown-radius-false-true:before {
  border-radius: 0 30px 30px 0;
}

.ms-padding-is-single-false-size-default {
  height: 36px;
  padding: 8px 10px 8px 10px;
}

.line {
  left: -10px;
  height: 20px;
  top: 0;
  position: absolute;
  border: 1px solid transparent;
  border-left-color: #fff;
}
/**Thanh filter */
.overview {
  margin-bottom: 36px;
  color: #fff;
}

.over-view:hover {
  padding-top: 0;
}

.overview .inner-overview .dued-debit-overview {
  background: #ff7f2c;
  height: 100%;
}

.overview .inner-overview .inner-overview-data {
  padding: 6px 10px;
  overflow: hidden;
}

.overview .inner-overview .overview-data-number {
  align-items: baseline;
}

.overview .inner-overview .overview-data-number .total-money {
  font-size: 24px;
}

.overview .inner-overview .label-overview {
  font-size: 13px;
}

.over-view:hover .over-view-line {
  padding-top: 8px;
  background: #707070;
  opacity: 0.5;
}

.overview .inner-overview .total-debit-overview {
  background: #b8bcc3;
  height: 100%;
}

.overview .inner-overview .payment-overview {
  background: #74cb2f;
  height: 100%;
}

/**Lọc và tìm kiếm */
.grid-list-data {
  background: #fff;
  padding: 16px 16px 10px 16px;
  position: relative;
  margin-top: 14px;
}

.grid-list-data .grid-button-list {
  margin-bottom: 10px;
}

.grid-list-data .grid-button-list .check-all-arrow {
  display: inline-block;
  padding: 13px 12px 0 12px;
}

.grid-list-data .grid-button-list #check-all-dropdown {
  margin-right: 12px;
  display: inline-block;
}

.grid-list-data .grid-button-list #filter-dropdown {
  display: inline-block;
  margin-right: 10px;
}

.grid-list-data .grid-button-list .ultility-buttons {
  justify-content: flex-end;
  align-items: center;
}

.ultility-buttons .list-button {
  padding: 0 6px;
}

.list-button {
  margin-right: 0 !important;
}

.collapse-overview {
  border: 2px solid #e2e9f2;
  background: #f2f5f8;
  position: absolute;
  width: 30px;
  height: 28px;
  top: -14px;
  right: 0;
  cursor: pointer;
}

/**Bảng */
.grid-model-control {
  min-width: 100%;
}

.table-area {
  overflow: unset;
  max-height: none;
  min-width: calc(100% + 30px);
}

.ms-grid-viewer .ms-table-viewer {
  border-spacing: 0;
  border-collapse: separate;
  min-width: 100%;
}

.ms-out-left-white-16 {
  min-width: 16px;
  max-width: 16px;
  width: 16px;
  background: #fff;
  position: sticky;
  left: 0;
  border: 0;
  z-index: 3;
  padding: 0;
}

.ms-out-right-grey-30,
.ms-out-right-white-30 {
  min-width: 30px;
  position: sticky;
  border: none;
  width: 30px;
  max-width: 30px;
  z-index: 3;
  padding: 0;
}

.ms-out-right-white-30 {
  background: #fff;
  right: 0;
}

.ms-out-right-grey-30 {
  background: #f4f5f6;
  right: -30px;
}

.ms-grid-viewer
  .ms-table-viewer
  .ms-thead-viewer
  .ms-tr-viewer
  .ms-muli-checkall {
  z-index: 3;
  position: sticky;
  left: 0;
  top: 0;
  min-width: 40px;
  width: 40px;
  max-width: 40px;
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  min-height: 34px;
  height: 34px;
}

.ms-grid-viewer .ms-table-viewer .ms-tbody-viewer {
  background-color: #fff;
}

.dis-contents {
  display: contents;
}

/**TH */
.ms-grid-viewer .ms-table-viewer .ms-thead-viewer .ms-tr-viewer .dymamic-col {
  left: unset !important;
}

.ms-grid-viewer .ms-table-viewer .ms-thead-viewer .ms-tr-viewer .ms-th-viewer {
  border-right: 1.5px solid #c7c7c7;
  border-bottom: 1.6px solid #c7c7c7;
  min-height: 34px;
  height: 34px;
  position: sticky;
  z-index: 2;
  top: 0;
  background-color: #eceef1;
  vertical-align: middle;
}

.ms-th-viewer {
  top: 93px !important;
}

.ms-grid-viewer
  .ms-table-viewer
  .ms-thead-viewer
  .ms-tr-viewer
  .ms-th-viewer
  .ms-head-title {
  font-size: 12px;
  text-transform: uppercase !important;
  align-items: center;
  cursor: pointer;
  padding-right: 12px;
}

.icon-head {
  height: -webkit-fit-content;
  height: -moz-fit-content;
  height: fit-content;
  position: absolute;
  right: 3px;
  top: calc(50% - 8px);
}

.reverse {
  transform: rotate(180deg);
}

/**Cột chức năng */
.ms-grid-viewer .ms-table-viewer .ms-thead-viewer .ms-tr-viewer .ms-th-wiget {
  border-right: none;
  position: sticky;
  right: 0;
  z-index: 4;
  border-left: 1.5px solid #c7c7c7;
}

.ms-grid-viewer
  .ms-table-viewer
  .ms-thead-viewer
  .ms-tr-viewer
  .ms-th-viewer
  .ms-head-title.float-right {
  display: block;
  text-align: right;
}

.ms-grid-viewer
  .ms-table-viewer
  .ms-thead-viewer
  .ms-tr-viewer
  .ms-th-viewer
  .ms-head-title {
  text-transform: uppercase !important;
  align-items: center;
  cursor: pointer;
  padding-right: 12px;
}

/**TBODY */
.ms-grid-viewer .ms-table-viewer .ms-tbody-viewer .ms-tr-viewer,
.ms-grid-viewer .ms-table-viewer .ms-tbody-viewer {
  background-color: #fff;
}

.ms-tr-viewer .ms-td-viewer {
  height: 40px;
  padding: 5px 10px;
  border-bottom: 1.5px solid #c7c7c7;
  border-right: 1.5px dotted #c7c7c7;
  font-size: 13px;
}

.ms-tr-viewer:hover .ms-td-viewer {
  background: #f3f8f8 !important;
}

.ms-dropdown {
  display: flex;
}

/**nút sửa */
.ms-tr-viewer .ms-td-wiget {
  border-right: none;
  position: sticky;
  right: 30px;
  z-index: 2;
  background-color: #fff;
  border-left: 1px dotted #c7c7c7;
}

.edit-btn {
  padding: 6px 0 6px 16px !important;
  color: #0075c0;
  height: 36px;
}

.function-btn {
  width: 46px;
  color: #0075c0;
  height: 36px;
  padding: 8px 10px 8px 10px;
  position: relative;
}

/**phân trang */
/* .ms-panigation {
  bottom: 0px;
  width: calc(100vw - 221px);
  position: sticky;
  bottom: 0;
  z-index: 2;
  background-color: #fff;
  display: flex;
} */

.ms-grid-viewer .ms-pagination {
  bottom: 0px;
  /* width: calc(100vw - 221px); */
  position: sticky;
  bottom: 0;
  z-index: 2;
  background-color: #fff;
  display: flex;
}

.ms-grid-viewer .ms-pagination .pagination-bar {
  min-height: 46px;
}

.left-pagination {
  position: sticky;
  left: 20px;
  white-space: nowrap;
  min-width: 10px;
  display: flex;
}

.postion-pagination {
  position: sticky;
  right: 60px;
}

.record-in-page {
  margin: 0 16px;
  width: fit-content;
  min-width: 200px;
}

/**combobox số bản ghi trên 1 trang */
.ms-combo {
  position: relative;
  width: 100%;
}

.ms-combo .combo-main-content {
  display: flex;
  min-height: 32px;
  border: 1px solid #babec5;
  border-radius: 2px;
  background-color: #fff;
  overflow: hidden;
}

.ms-combo .combo-main-content .selected-options {
  display: flex;
  flex-basis: 100%;
  flex-grow: 1;
  flex-wrap: wrap;
  width: calc(100% - 32px);
  align-items: center;
  padding: 6px 0 6px 12px;
}

.ms-combo .combo-main-content .selected-options .combo-input {
  border: none;
  font-size: 13px;
  padding-right: unset;
  text-overflow: ellipsis;
  background-color: transparent;
  display: flex;
  flex-grow: 1;
}

.ms-combo .combo-main-content .combo-actions {
  display: flex;
}

.ms-combo .combo-main-content .combo-actions .btn-dropdown {
  width: 32px;
  background-color: transparent;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}

.ms-combo .combo-main-content .combo-actions .arrow-dropdown--close {
  transform: rotate(0deg);
  transition: transform 0.15s linear;
}

.ms-combo .combo-main-content .combo-actions .arrow-dropdown--open {
  transform: rotate(180deg);
  transition: transform 0.15s linear;
}

.ms-combo .combo-main-content .combo-actions .btn-dropdown:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

/**Số trang */
.disableText {
  cursor: default !important;
  color: #9e9e9e;
}
.unselect {
  -webkit-touch-callout: none;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

.page-index {
  display: flex;
}

.pageSelected {
  border: 1px solid #e0e0e0;
  font-weight: 700;
}

/* input:focus{
  border: 1px solid #2ca01c !important;
} */

/**CSS menu hiện lên trên từng dòng */
.con-ms-dropdown--menu {
  padding-top: 10px;
  position: absolute;
  height: auto;
  width: auto;
  z-index: 1001;
  transform: translate(-100%);
  transition: opacity 0.25s, transform 0.25s, width 0.3s ease;
}

.ms-dropdown--menu {
  background: #fff;
  padding: 2px 1px;
  border-radius: 2px;
  border: 1px solid #babec5;
  position: relative;
}

.ms-dropdown--item {
  white-space: nowrap;
  transition: all 0.2s ease;
  position: relative;
  z-index: 1000;
  text-align: left;
  width: 100%;
  list-style: none;
  min-width: 100px;
  font-weight: 400 !important;
  font-size: 13px;
}

.ms-dropdown--item:hover {
  background: #e8e9ec;
  color: #08bf1e;
}

.ms-dropdown--item .ms-dropdown--item-link {
  background: inherit !important;
  color: inherit !important;
  cursor: pointer;
  transition: all 0.2s ease;
  padding: 5px;
  padding-left: 10px;
  padding-right: 10px;
  width: 100%;
  position: relative;
  display: block;
  color: rgba(0, 0, 0, 0.7);
}

/* dialog Xóa  */
.RightSecond {
  float: right;
  padding-left: 8px;
}
</style>
