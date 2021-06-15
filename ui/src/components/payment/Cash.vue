<template>
  <div class="content-area__content">
    <div class="body body-di">
      <!-- Phần thêm nhà cung cấp  -->
      <div class="title-distance lock-title-distance">
        <div class="header-di">
          <div class="title-di">Thu chi tiền mặt</div>
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
                      <a class="ms-dropdown--item-link">Chưa có tiện ích </a>
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
                  @click="showPaymentPopup()"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Thêm chi tiền
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
                  <div class="total-money">100.000.000,00</div>
                </div>
                <div class="label-overview">Tổng thu đầu năm đến hiện tại</div>
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
                <div class="label-overview">Tổng chi đầu năm đến hiện tại</div>
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
                <div class="label-overview">Tồn quỹ hiện tại</div>
              </div>
              <div class="over-view-line"></div>
            </div>
          </div>
        </div>
      </div>

      <!-- tìm kiếm -->
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

              <div class="filter-conditions">
                <div class="filter-item--default">Đầu năm tới hiện tại</div>
              </div>
            </div>

            <div class="flex search-wrapper">
              <div class="ms-input">
                <input
                  id="input-search-supplier"
                  class="input-search hasIcon"
                  type="text"
                  placeholder="Nhập từ khóa tìm kiếm"
                  v-model="keyWordSearch"
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
                        >Ngày hạch toán
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-180">
                      <span class="ms-head-title flex justify-left"
                        >Ngày chứng từ
                        <!-- <div class="mi mi-16" style="display: none"></div> -->
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-150">
                      <span class="ms-head-title flex justify-left"
                        >Số chứng từ
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Diễn giải
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-150">
                      <span class="ms-head-title flex justify-left"
                        >Số tiền
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-180">
                      <span class="ms-head-title flex justify-left"
                        >Đối tượng
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-180">
                      <span class="ms-head-title flex justify-left"
                        >Mã đối tượng
                        <div class="mi mi-16" style="display: none"></div>
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
                <tr class="ms-tr-viewer">
                  <td class="ms-out-left-white-16"></td>
                  <td class="ms-td-viewer ms-td-multi" style="left: 16px">
                    <check-box></check-box>
                  </td>
                  <td class="ms-td-viewer text-left">15/06/2021</td>
                  <td class="ms-td-viewer text-left">15/06/2021</td>
                  <td class="ms-td-viewer text-left">PC0005</td>
                  <td class="ms-td-viewer text-left">Chi tiền cho nhân viên</td>
                  <td class="ms-td-viewer text-right">50.000.000</td>
                  <td class="ms-td-viewer text-left">Trần dần</td>
                  <td class="ms-td-viewer text-left">NV1150</td>
                  <td class="ms-td-viewer text-left">SỐ 1 cầu giấy</td>
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
                                  showPopup(),
                                    setIsReadOnlyTrue(),
                                    (idSupplier = supplier.idsupplier)
                                "
                                >Xem
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
                              <a class="ms-dropdown--item-link">Nhân bản </a>
                            </div>
                          </template>
                        </dropdown-button>
                      </div>
                    </div>
                  </td>
                  <td class="ms-out-right-white-30"></td>
                  <td class="ms-out-right-grey-30"></td>
                </tr>
                <!-- <tr
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
                                  showPopup(),
                                    setIsReadOnlyTrue(),
                                    (idSupplier = supplier.idsupplier)
                                "
                                >Xem
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
                               
                                >Nhân bản
                              </a>
                            </div>
                          </template>
                        </dropdown-button>
                      </div>
                    </div>
                  </td>
                  <td class="ms-out-right-white-30"></td>
                  <td class="ms-out-right-grey-30"></td>
                </tr> -->
              </tbody>

              <!-- chân bảng  -->
              <tfoot class="ms-tfoot-viewer">
                <tr class="ms-tr-viewer">
                  <th class="ms-out-left-white-16" style="bottom: 46px"></th>
                  <th
                    class="ms-th-viewer multiple-footer"
                    style="bottom: 46px; left: 16px"
                  ></th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-center">
                      <span>Tổng</span>
                    </div>
                  </th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>

                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-end">
                      <span>1.000.000,0</span>
                    </div>
                  </th>

                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>
                  <th class="ms-th-viewer dymamic-col" style="bottom: 46px">
                    <div class="flex justify-start">
                      <span></span>
                    </div>
                  </th>

                  <th
                    class="ms-th-viewer ms-th-wiget wiget-footer"
                    style="
                      right: 30px;
                      width: 110px;
                      min-width: 110px;
                      bottom: 46px;
                    "
                  ></th>
                  <th
                    class="ms-out-right-white-30"
                    style="bottom: 46px"
                  ></th>
                  <th
                    class="ms-out-right-grey-30"
                    style="bottom: 46px"
                  ></th>
                </tr>
              </tfoot>
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
            <div class="ms-pagination" style="width: 1756px">
              <div
                class="flex items-center justify-between w-full pagination-bar"
              >
                <div class="left-pagination">
                  <div class="total-record">
                    Tổng số: <b>{{ paymentsLength }}</b> bản ghi
                  </div>
                </div>
                <div class="flex postion-pagination align-center">
                  <div class="record-in-page">
                    <ms-select
                      :items="recordInPage"
                      v-model="pageSizeInSelect"
                    ></ms-select>
                  </div>

                  <div style="display: flex; align-items: center">
                    <div
                      class="mr-3 pointer"
                      :class="{ disableText: pageNumber == 1 }"
                      @click="prePage()"
                    >
                      Trước
                    </div>
                    <div class="page-index">
                      <div class="pl-2 pr-2 pointer pageSelected">
                        {{ pageNumber }}
                      </div>
                    </div>
                    <div
                      class="ml-3 pointer"
                      :class="{
                        disableText: pageNumber * pageSize >= suppliersLength,
                      }"
                      @click="nextPage()"
                    >
                      Sau
                    </div>
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
    <payment
      @closePaymentPopup="closePaymentPopup"
      :isShowPopup="isShowPaymentPopup"
    ></payment>
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
  </div>
</template>

<script>
import DropdownButton from "../baseControl/DropdownButton.vue";
import Payment from "./Payment.vue";
import CheckBox from "../baseControl/CheckBox.vue";

export default {
  name: "Cash",
  components: {
    DropdownButton,
    Payment,
    CheckBox,
  },
  data() {
    return {
      loading: false,
      isShowPaymentPopup: false,
      payments: [],
      paymentsLength: 0,
      pageNumber: 1,
      pageSize: 20,
      pageSizeInSelect: "20 bản ghi trên 1 trang",
    };
  },
  methods: {
    showPaymentPopup() {
      this.isShowPaymentPopup = true;
    },

    closePaymentPopup(value) {
      this.isShowPaymentPopup = value;
    },
  },
  mounted() {},
};
</script>
<style scoped>
.body {
  padding-right: 30px;
  overflow: scroll;
  height: calc(100vh - 48px);
}

.body-di {
  max-height: unset !important;
}
</style>
<style>
.grid-list-data .grid-button-list .filter-conditions {
  display: inline;
  align-items: center;
  line-height: 35px;
}

.grid-list-data .grid-button-list .filter-conditions .filter-item--default {
  display: inline-block;
  margin-right: 10px;
  color: #111;
  white-space: nowrap;
}

/* chân bảng  */
.ms-grid-viewer .ms-table-viewer .ms-tfoot-viewer .ms-tr-viewer .ms-th-viewer {
  border-top: 1px solid #c7c7c7;
  min-height: 34px;
  position: sticky;
  z-index: 1;
  top: 0;
  background-color: #f8f9fe;
  bottom: 0;
  font-size: 12px;
  vertical-align: middle;
}

.ms-grid-viewer .ms-table-viewer .ms-tfoot-viewer .ms-tr-viewer .ms-th-viewer {
  border-top: 1px solid #c7c7c7;
  min-height: 34px;
  position: sticky;
  z-index: 1;
  top: 0;
  background-color: #f8f9fe;
  bottom: 0;
  font-size: 12px;
  vertical-align: middle;
}
</style>
