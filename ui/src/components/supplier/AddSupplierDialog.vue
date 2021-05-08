<template>
  <div class="modal fade" id="add-supplier-dialog">
    <div class="modal-dialog modal-xl modal-dialog-centered">
      <div class="modal-content h-625">
        <!-- Dialog Header -->
        <div class="modal-header border-0 p-0">
          <div class="ms-popup--title">
            <div class="header-popup flex">
              <div class="title-popup">Thông tin nhà cung cấp</div>
              <div class="px-4 flex">
                <div class="flex">
                  <div class="con-ms-radio">
                    <input
                      type="radio"
                      id="organization"
                      name="radio-group"
                      value="organization"
                      v-model="typeOfSupplier"
                    />
                    <label for="organization" class="mr-4">Tổ chức</label>
                  </div>
                  <div class="con-ms-radio">
                    <input
                      type="radio"
                      id="personal"
                      name="radio-group"
                      value="personal"
                      v-model="typeOfSupplier"
                    />
                    <label for="personal">Cá nhân</label>
                  </div>
                </div>
              </div>
              <check-box
                class="mlp-100"
                label="Là khách hàng"
                v-model="isCustomer"
              ></check-box>
            </div>
          </div>

          <div class="ms-popup-close">
            <div
              class="mi mi-24 mi-help mr-6-px help-btn"
              title="Trợ giúp"
            ></div>
            <div
              class="mi mi-24 mi-close"
              data-dismiss="modal"
              title="Đóng (ESC)"
            ></div>
          </div>
        </div>

        <!-- Dialog body -->
        <div class="ms-popup--content popup-h-73">
          <div class="popup-content customer-scroll">
            <div class="flex">
              <div class="w-1/2 p-r-26">
                <div class="flex row-input">
                  <div
                    v-if="typeOfSupplier == 'organization'"
                    class="w-2/5 p-r-12 position-relative"
                  >
                    <ms-input label="Mã số thuế"></ms-input>
                  </div>
                  <div
                    class="w-3/5"
                    :class="{ 'p-r-12': typeOfSupplier == 'personal' }"
                  >
                    <ms-input
                      label="Mã nhà cung cấp"
                      :required="true"
                    ></ms-input>
                  </div>
                  <div
                    v-if="typeOfSupplier == 'personal'"
                    class="w-2/5 p-r-12 position-relative"
                  >
                    <ms-input label="Mã số thuế"></ms-input>
                  </div>
                </div>

                <div class="w-full row-input position-relative">
                  <ms-input
                    v-if="typeOfSupplier == 'organization'"
                    label="Tên nhà cung cấp"
                    :required="true"
                  ></ms-input>
                  <div v-if="typeOfSupplier == 'personal'">
                    <div class="label-input">Tên nhà cung cấp</div>
                    <div class="flex">
                      <div class="w-1/3 pr-2">
                        <select-auto-complete
                          placeholder="Xưng hô"
                          :items="vocatives"
                        ></select-auto-complete>
                      </div>
                      <div class="w-2/3">
                        <ms-input label="" placeholder="Họ và tên"></ms-input>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="w-full row-input position-relative">
                  <ms-textarea
                    label="Địa chỉ"
                    placeholder="VD: Số 82 Duy Tân, Dịch Vọng Hậu, Cầu Giấy, Hà Nội"
                  ></ms-textarea>
                </div>
              </div>

              <div class="w-1/2">
                <div
                  class="flex row-input"
                  v-if="typeOfSupplier == 'organization'"
                >
                  <div class="w-2/5 p-r-12 position-relative">
                    <ms-input label="Điện thoại"></ms-input>
                  </div>
                  <div class="w-3/5">
                    <ms-input label="Website"></ms-input>
                  </div>
                </div>

                <div class="w-full row-input">
                  <select-auto-complete-menu-table label="Nhóm nhà cung cấp"></select-auto-complete-menu-table>
                </div>

                <div class="w-full row-input">
                  <ms-input label="Nhân viên mua hàng"></ms-input>
                </div>
              </div>
            </div>

            <!-- nav tabs -->
            <div class="w-full mt-2">
              <div class="navigation-tab">
                <ul class="nav nav-tabs" role="tablist">
                  <li class="nav-item">
                    <a
                      class="nav-link active"
                      data-toggle="tab"
                      href="#contact-tab"
                    >
                      <div class="ms-label tab-label">Liên hệ</div></a
                    >
                  </li>
                  <li class="nav-item">
                    <a
                      class="nav-link"
                      data-toggle="tab"
                      href="#terms-of-payment-tab"
                      >Điều khoản thanh toán</a
                    >
                  </li>
                  <li class="nav-item">
                    <a
                      class="nav-link"
                      data-toggle="tab"
                      href="#bank-account-tab"
                      >Tài khoản ngân hàng</a
                    >
                  </li>
                  <li class="nav-item">
                    <a
                      class="nav-link"
                      data-toggle="tab"
                      href="#other-address-tab"
                      >Địa chỉ khác</a
                    >
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" data-toggle="tab" href="#note-tab"
                      >Ghi chú</a
                    >
                  </li>
                </ul>

                <div class="tab-content">
                  <div id="contact-tab" class="tab-pane active">
                    <div class="flex tab-con-content">
                      <div class="w-1/2 p-r-26">
                        <div
                          class="w-full pb-2"
                          v-if="typeOfSupplier == 'organization'"
                        >
                          <div class="label-input">Người liên hệ</div>
                          <div class="flex">
                            <div class="w-1/3 pr-2">
                              <select-auto-complete
                                placeholder="Xưng hô"
                                :items="vocatives"
                              ></select-auto-complete>
                            </div>
                            <div class="w-2/3">
                              <ms-input
                                label=""
                                placeholder="Họ và tên"
                              ></ms-input>
                            </div>
                          </div>
                        </div>

                        <div
                          v-if="typeOfSupplier == 'personal'"
                          class="label-input"
                        >
                          Thông tin liên hệ
                        </div>
                        <div class="w-full pb-2">
                          <ms-input id="email" placeholder="Email"></ms-input>
                        </div>

                        <div
                          class="w-1/2 pb-2"
                          v-if="typeOfSupplier == 'organization'"
                        >
                          <ms-input placeholder="Số điện thoại"></ms-input>
                        </div>
                        <div
                          class="w-1/2 pb-2"
                          v-if="typeOfSupplier == 'personal'"
                        >
                          <ms-input placeholder="Điện thoại di động"></ms-input>
                        </div>
                        <div
                          class="w-1/2 pb-2"
                          v-if="typeOfSupplier == 'personal'"
                        >
                          <ms-input placeholder="Điện thoại cố định"></ms-input>
                        </div>
                        <div class="w-full">
                          <ms-input
                            v-if="
                              typeOfSupplier == 'personal' ||
                              (typeOfSupplier == 'organization' && isCustomer)
                            "
                            label="Đại diện theo PL"
                            placeholder="Đại diện theo PL"
                          ></ms-input>
                        </div>
                      </div>

                      <div class="w-1/2">
                        <div
                          class="w-full"
                          v-if="typeOfSupplier == 'organization' && !isCustomer"
                        >
                          <ms-input
                            label="Đại diện theo PL"
                            placeholder="Đại diện theo PL"
                          ></ms-input>
                        </div>

                        <div v-if="typeOfSupplier == 'personal'">
                          <div class="label-input">
                            Thông tin CMND/Thẻ căn cước
                          </div>
                          <div class="w-1/2 pb-2">
                            <ms-input
                              placeholder="Số CMND/Thẻ căn cước"
                            ></ms-input>
                          </div>
                          <div class="w-1/2 pb-2 input-date-picker">
                            <ms-input-date></ms-input-date>
                          </div>
                          <div class="w-full">
                            <ms-input placeholder="Nơi cấp"></ms-input>
                          </div>
                        </div>

                        <div
                          v-if="typeOfSupplier == 'organization' && isCustomer"
                        >
                          <div class="label-input">
                            Người nhận hóa đơn điện tử
                          </div>
                          <div class="w-full pb-2">
                            <ms-input
                              placeholder="Họ và tên"
                            ></ms-input>
                          </div>
                          <div class="w-full pb-2">
                            <ms-input placeholder='Email, ngăn cách nhiều email bởi dấu chấm phẩy ";"'></ms-input>
                          </div>
                          <div class="w-1/2">
                            <ms-input placeholder="Số điện thoại"></ms-input>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div id="terms-of-payment-tab" class="tab-pane fade">
                    <div class="tab-con-content">
                      <div class="flex row-input">
                        <div class="w-input p-r-12">
                          <div class="w-full">
                            <ms-input label="Điều khoản thanh toán"></ms-input>
                          </div>
                        </div>

                        <div class="w-input p-r-12">
                          <div class="w-full">
                            <ms-input label="Số ngày được nợ"></ms-input>
                          </div>
                        </div>

                        <div class="w-input p-r-12">
                          <div class="w-full">
                            <ms-input label="Số nợ tối đa"></ms-input>
                          </div>
                        </div>
                      </div>

                      <div class="flex row-input">
                        <div class="flex w-input p-r-12" v-if="isCustomer">
                          <ms-input
                            label="Tài khoản công nợ phải thu"
                          ></ms-input>
                        </div>
                        <div class="flex w-input p-r-12">
                          <ms-input
                            label="Tài khoản công nợ phải trả"
                          ></ms-input>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div id="bank-account-tab" class="tab-pane fade">
                    <div class="tab-con-content">
                      <div class="grid-model-control">
                        <div class="gridComponent">
                          <div class="ms-component ms-grid-editable-con">
                            <div class="con-tablex">
                              <div class="border-color">
                                <div class="flex">
                                  <div
                                    class="table-scroll dynamic-table"
                                    style="min-height: 0px; overflow: auto"
                                  >
                                    <table
                                      class="ms-table"
                                      style="min-width: calc(100% + 0px)"
                                    >
                                      <thead class="ms-table--thead">
                                        <tr>
                                          <th class="dynamic-header p-0 w-150">
                                            <div
                                              class="flex th-height text-left"
                                            >
                                              <div
                                                class="th-table padding-th w-full cursor-pointer"
                                              >
                                                <span>Số tài khoản</span>
                                              </div>
                                            </div>
                                          </th>

                                          <th class="dynamic-header p-0 w-200">
                                            <div
                                              class="flex th-height text-left"
                                            >
                                              <div
                                                class="th-table padding-th w-full cursor-pointer"
                                              >
                                                <span>Tên ngân hàng</span>
                                              </div>
                                            </div>
                                          </th>

                                          <th class="dynamic-header p-0 w-180">
                                            <div
                                              class="flex th-height text-left"
                                            >
                                              <div
                                                class="th-table padding-th w-full cursor-pointer"
                                              >
                                                <span>Chi nhánh</span>
                                              </div>
                                            </div>
                                          </th>

                                          <th
                                            class="dynamic-header p-0"
                                            style="min-width: 200px; top: 0px"
                                          >
                                            <div
                                              class="flex th-height text-left"
                                            >
                                              <div
                                                class="th-table padding-th w-full cursor-pointer"
                                              >
                                                <span
                                                  >Tỉnh/TP của ngân hàng</span
                                                >
                                              </div>
                                            </div>
                                          </th>

                                          <th
                                            class="text-right wiget wiget-title right-0"
                                            style="
                                              min-width: 40px;
                                              width: 40px;
                                              max-width: 40px;
                                              top: 0px;
                                            "
                                          ></th>
                                        </tr>
                                      </thead>

                                      <tbody class="dis-contents">
                                        <tr
                                          class="tr-values vs-table--tr tr-table-state-null select-row selected"
                                        >
                                          <td
                                            class="td ms-table--td dynamic-column"
                                          >
                                            <ms-input></ms-input>
                                          </td>
                                          <td
                                            class="td ms-table--td dynamic-column"
                                          >
                                            <ms-input></ms-input>
                                          </td>
                                          <td
                                            class="td ms-table--td dynamic-column"
                                          >
                                            <ms-input></ms-input>
                                          </td>
                                          <td
                                            class="td ms-table--td dynamic-column"
                                          >
                                            <ms-input></ms-input>
                                          </td>
                                          <td
                                            class="td ms-table--td wiget right-0"
                                          >
                                            <div
                                              class="delete-function flex justify-end align-center"
                                            >
                                              <div
                                                class="mi mi-16 mi-delete"
                                              ></div>
                                            </div>
                                          </td>
                                        </tr>
                                      </tbody>
                                    </table>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>

                      <div class="grid-control-item">
                        <div class="btn-grid-control">
                          <button
                            class="ms-component ms-button ms-button-size-small ms-button-secondary ms-button-secondary-disabled-false ms-button-radius-false ms-button"
                          >
                            <div
                              class="ms-button-text ms-button--text flex align-center"
                            >
                              <div>Thêm dòng</div>
                            </div>
                          </button>

                          <button
                            class="ms-component ms-button ms-button-size-small ms-button-secondary ms-button-secondary-disabled-false ms-button-radius-false ms-button"
                          >
                            <div
                              class="ms-button-text ms-button--text flex align-center"
                            >
                              <div>Xóa hết dòng</div>
                            </div>
                          </button>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div id="other-address-tab" class="tab-pane fade">
                    <div class="flex tab-con-content">
                      <div class="w-1/2 p-r-26">
                        <div class="label-input">Vị trí địa lý</div>
                        <div class="flex row-input">
                          <div class="w-1/2 p-r-12">
                            <select-auto-complete
                              placeholder="Quốc gia"
                            ></select-auto-complete>
                          </div>
                          <div class="w-1/2">
                            <select-auto-complete
                              placeholder="Tỉnh/Thành phố"
                            ></select-auto-complete>
                          </div>
                        </div>

                        <div class="flex">
                          <div class="w-1/2 p-r-12">
                            <select-auto-complete
                              placeholder="Quận/Huyện"
                            ></select-auto-complete>
                          </div>
                          <div class="w-1/2">
                            <select-auto-complete
                              placeholder="Xã/Phường"
                            ></select-auto-complete>
                          </div>
                        </div>
                      </div>

                      <div class="w-1/2">
                        <div class="top-grid">
                          <div class="label-input">Địa chỉ giao hàng</div>
                          <div class="address-combo">
                            <check-box
                              label="Giống địa chỉ nhà cung cấp"
                            ></check-box>
                          </div>
                        </div>

                        <div class="grid-model-control grid-address">
                          <div class="gridComponent">
                            <div class="ms-component ms-grid-editable-con">
                              <div class="con-tablex">
                                <div class="border-color">
                                  <div class="flex">
                                    <div
                                      class="table-scroll dynamic-table"
                                      style="min-height: 0px; overflow: auto"
                                    >
                                      <table
                                        class="ms-table"
                                        style="min-width: calc(100% + 0px)"
                                      >
                                        <thead class="ms-table--thead">
                                          <tr>
                                            <th
                                              class="dynamic-header p-0 w-100"
                                            >
                                              <div
                                                class="flex th-height text-left"
                                              >
                                                <div
                                                  class="th-table padding-th w-full cursor-pointer"
                                                >
                                                  <span
                                                    >Địa điểm giao hàng</span
                                                  >
                                                </div>
                                              </div>
                                            </th>

                                            <th
                                              class="text-right wiget wiget-title right-0"
                                              style="
                                                min-width: 40px;
                                                width: 40px;
                                                max-width: 40px;
                                                top: 0px;
                                              "
                                            ></th>
                                          </tr>
                                        </thead>

                                        <tbody class="dis-contents">
                                          <tr
                                            class="tr-values vs-table--tr tr-table-state-null select-row selected"
                                          >
                                            <td
                                              class="td ms-table--td dynamic-column"
                                            >
                                              <ms-input></ms-input>
                                            </td>
                                            <td
                                              class="td ms-table--td wiget right-0"
                                            >
                                              <div
                                                class="delete-function flex justify-end align-center"
                                              >
                                                <div
                                                  class="mi mi-16 mi-delete"
                                                ></div>
                                              </div>
                                            </td>
                                          </tr>
                                        </tbody>
                                      </table>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="grid-control-item">
                          <div class="btn-grid-control">
                            <button
                              class="ms-component ms-button ms-button-size-small ms-button-secondary ms-button-secondary-disabled-false ms-button-radius-false ms-button"
                            >
                              <div
                                class="ms-button-text ms-button--text flex align-center"
                              >
                                <div>Thêm dòng</div>
                              </div>
                            </button>

                            <button
                              class="ms-component ms-button ms-button-size-small ms-button-secondary ms-button-secondary-disabled-false ms-button-radius-false ms-button"
                            >
                              <div
                                class="ms-button-text ms-button--text flex align-center"
                              >
                                <div>Xóa hết dòng</div>
                              </div>
                            </button>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div id="note-tab" class="tab-pane fade">
                    <div class="tab-con-content description">
                      <ms-textarea> </ms-textarea>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="ms-popup-footer">
            <div class="divide"></div>
            <div class="flex footer-button-group">
              <div class="w-full flex align-right">
                <div class="flex align-right">
                  <div class="p-x-3">
                    <button
                      class="ms-button-size-default ms-button-secondary ms-button-radius-false ms-button"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Cất
                      </div>
                    </button>
                  </div>
                  <div>
                    <button
                      class="ms-button-size-default ms-button-primary ms-button-radius-false ms-button"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Cất và Thêm
                      </div>
                    </button>
                  </div>
                </div>
              </div>

              <div class="w-1/2" style="position: absolute">
                <button
                  class="ms-button-size-default ms-button-secondary ms-button-radius-false ms-button"
                  data-dismiss="modal"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Hủy
                  </div>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- thông báo lỗi  -->
    <!-- <div class="modal fade" id="error-dialog">
      <div
        class="modal-dialog modal-dialog-centered"
        style="width: 444px; min-width: 444px"
      >
        <div class="modal-content">
          <div class="padding-32">
            <div class="content">
              <div class="icon-message">
                <div class="mi mi-48 mi-exclamation-error-48-2"></div>
              </div>
              <div class="message-content p-l-16 p-t-12">
                <span id="idMessageError" class="message"
                  ></span
                >
              </div>
            </div>
            <div class="mess-line"></div>
            <div class="mess-footer">
              <div class="Center">
                <button
                  name="button"
                  class="ms-component ms-button ms-button-size-default ms-button-primary ms-button-primary-disabled-false ms-button-radius-false ms-button"
                  @click="hideErrorDialog()"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Đóng
                  </div>
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div> -->

    <div class="con-ms-message-box" id="error-dialog">
      <div class="message-center">
        <div class="ms-message-bg"></div>
        <div class="drag-it-dude">
          <div class="ms-mesage-box">
            <div style="width: 444px; min-width: 444px">
              <div class="padding-32">
                <div class="content">
                  <div class="icon-message">
                    <div class="mi mi-48 mi-exclamation-error-48-2"></div>
                  </div>
                  <div class="message-content p-l-16 p-t-12">
                    <span id="idMessageError" class="message"></span>
                  </div>
                </div>
                <div class="mess-line"></div>
                <div class="mess-footer">
                  <div class="Center">
                    <button
                      name="button"
                      class="ms-component ms-button ms-button-size-default ms-button-primary ms-button-primary-disabled-false ms-button-radius-false ms-button"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Đóng
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
import MsInput from "../baseControl/MsInput.vue";
import MsTextarea from "../baseControl/MsTextarea.vue";
import MsInputDate from "../baseControl/MsInputDate.vue";
import CheckBox from "../baseControl/CheckBox.vue";
import SelectAutoComplete from "../baseControl/SelectAutoComplete.vue";
import SelectAutoCompleteMenuTable from "../baseControl/SelectAutoCompleteMenuTable.vue"

export default {
  components: {
    MsInput,
    MsTextarea,
    MsInputDate,
    CheckBox,
    SelectAutoComplete,
    SelectAutoCompleteMenuTable
  },

  data() {
    return {
      supplierCode: "",
      vocatives: ["Anh", "Bà", "Bạn", "Chị", "Ông"],
      // isOrganization: true,
      // isPersonal: false,
      typeOfSupplier: "organization", //or personal
      isCustomer: false,
    };
  },
};
</script>
<style>
/**Dialog */
.modal-lg,
.modal-xl {
  min-width: 900px !important;
  max-width: 900px !important;
  width: 900px !important;
}

@media (max-width: 992px) {
  .modal-lg,
  .modal-xl {
    max-width: 100% !important;
    /* margin: 0 !important; */
  }
}

.modal .input-is-focus {
  border: 1px solid #babec5;
}

.input-is-focus:focus {
  border-color: #2ca01c;
  box-shadow: none !important;
}

.modal .input-is-focus:focus:hover {
  /* border: 1px solid #babec5; */
  outline: none;
}

.modal .input-is-focus:hover {
  /* border: 1px solid #babec5; */
  /* outline: 1px solid #e2e2e2; */
}

.ms-popup--title {
  width: 100%;
  padding: 20px 32px 20px 32px;
  padding-right: 12px;
  position: relative;
  overflow: hidden;
  border-radius: 5px 5px 0 0;
}

.header-popup .title-popup {
  font-size: 24px;
  color: #111;
  font-weight: 700;
}

/**nút tắt dialog */
.ms-popup-close {
  display: flex;
  padding: 12px;
}

/**Dialog body */
.ms-popup--content {
  transition: all 0.23s ease 0.1s;
  flex-direction: column;
  display: flex;
  overflow: auto;
  overflow-y: visible;
  padding: 0 32px 20px 32px;
}

@media only screen and (max-height: 768px) {
  .popup-h-73 {
    height: calc(100% - 73px);
  }
}

.customer-scroll {
  overflow: auto;
}

.row-input {
  padding-bottom: 12px;
}

.label-for-input-requied {
  color: red;
  margin: 0;
  margin-left: 4px;
}

.combo-main-con {
  display: flex;
  height: calc(1.5em + 0.75rem + 2px);
  border: 1px solid #babec5;
  border-radius: 2px;
  background-color: #fff;
  overflow: hidden;
}

.combo-main-con .selected-options {
  display: flex;
  flex-basis: 100%;
  flex-grow: 1;
  flex-wrap: wrap;
  width: calc(100% - 32px);
}

.combo-main-con .selected-options .combo-input {
  border: none !important;
  font-size: 13px;
  padding: 5px 10px;
  padding-right: unset;
  text-overflow: ellipsis;
  background-color: transparent;
  display: flex;
  flex-grow: 1;
  width: 100%;
}

.combo-main-con .combo-actions {
  display: flex;
}

.combo-main-con .combo-actions .btn-dropdown {
  width: 32px;
  background-color: transparent;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}

.combo-main-con .combo-actions .btn-dropdown:hover {
  background-color: #e0e0e0;
  border-color: #e0e0e0;
}

/**Combobox Đơn vị */
.combo-menu {
  z-index: 10001;
  position: absolute;
  background-color: #fff;
  border: 1px solid #babec5;
  border-radius: 2px;
  overflow: hidden;
  box-shadow: 0 -8px 34px 0 rgb(0 0 0 / 5%);
}

.combo-menu .menu-header-container {
  background: #f4f5f8;
}

.combo-menu .menu-table {
  width: 100%;
  border-collapse: collapse;
}

.combo-menu .menu-header-container .menu-header {
  color: #111;
  height: 32px;
}

.combo-menu .menu-header-container .menu-header th {
  padding: 0 10px;
  height: 32px;
}

.combo-menu .menu-body-container {
  max-height: 160px;
  overflow-x: hidden;
  overflow-y: auto;
  padding: 2px 1px;
}

.scroller {
  scrollbar-color: #888 #f1f1f1;
  scrollbar-width: thin;
}

.combo-menu .menu-table {
  width: 100%;
  border-collapse: collapse;
}

.dropdown-item {
  display: flex;
  align-items: center;
  cursor: pointer;
  height: 32px;
  line-height: 32px;
  white-space: nowrap;
  padding: 0 !important;
}

.dropdown-item:focus,
.dropdown-item:hover {
  color: #35bf22 !important;
  background-color: #ebedf0 !important;
}

.dropdown-item .dropdown-item-td {
  padding: 0 10px;
}

.dropdown-item-td-first-col,
.dropdown-item-th-first-col {
  width: 100px;
  text-align: left;
}

.dropdown-item-td-second-col,
.dropdown-item-th-second-col {
  width: 250px;
  text-align: left;
}

.dropdown-item .dropdown-item-td .dropdown-item-td--contents {
  display: flex;
  align-items: center;
}

.dropdown-item .dropdown-item-td .dropdown-item-td--text {
  flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.dropdown-item .dropdown-item-td {
  padding: 0 10px;
}

.dropdown-item .dropdown-item-td .dropdown-item-td--contents {
  display: flex;
  align-items: center;
}

.dropdown-item .dropdown-item-td .dropdown-item-td--text {
  flex: 1;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.selected-container {
  width: 36px;
  height: 20px;
}

.label-input {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  color: #111;
}

.ms-radio-group {
  display: flex;
}

/**Radio button */
.con-ms-radio {
  position: relative;
  display: inline-flex;
  align-items: center;
  justify-content: flex-start;
  -webkit-box-align: center;
  -webkit-box-pack: center;
}

[type="radio"]:checked,
[type="radio"]:not(:checked) {
  position: absolute;
  left: -9999px;
}
[type="radio"]:checked + label,
[type="radio"]:not(:checked) + label {
  position: relative;
  padding-left: 28px;
  cursor: pointer;
  line-height: 20px;
  display: inline-block;
  /* color: #666; */
  margin-right: 12px;
}
[type="radio"]:checked + label:before,
[type="radio"]:not(:checked) + label:before {
  content: "";
  position: absolute;
  left: 0;
  top: 0;
  width: 18px;
  height: 18px;
  border: 1px solid #2ca01c;
  border-radius: 100%;
  background: #fff;
}
[type="radio"]:not(:checked) + label:before {
  border: 1px solid #afafaf;
}
[type="radio"]:checked + label:after,
[type="radio"]:not(:checked) + label:after {
  content: "";
  width: 10px;
  height: 10px;
  background: #2ca01c;
  position: absolute;
  top: 4px;
  left: 4px;
  border-radius: 100%;
  -webkit-transition: all 0.2s ease;
  transition: all 0.2s ease;
}
[type="radio"]:not(:checked) + label:after {
  opacity: 0;
  -webkit-transform: scale(0);
  transform: scale(0);
}
[type="radio"]:checked + label:after {
  opacity: 1;
  -webkit-transform: scale(1);
  transform: scale(1);
}

/**Navigation Tab */
.nav-tabs {
  border: none !important;
}

.nav-tabs .nav-link.active {
  color: #111 !important;
  background-color: #cce4f9 !important;
  height: 32px;
  border: 1px solid #c9ccd2 !important;
  border-bottom: none !important;
  /* padding: 0.5rem 1rem; */
  margin-top: 0;
}

.nav-tabs .nav-link {
  height: 26px;
  border: 1px solid #c9ccd2 !important;
  border-bottom: none !important;
  border-radius: 2px 2px 0 0;
  margin-right: 2px;
  color: #111;
  padding: 0 8px;
  margin-top: 6px;
  transition: all 0.2s ease;
  display: flex;
  place-items: center;
}

.nav-tabs .nav-link:first-child {
  margin-left: 1px;
}

.nav-tabs .nav-link:hover {
  color: #2ca01c !important;
}

.ms-label {
  text-align: center;
  white-space: nowrap;
  font-size: 13px;
}

.tab-content {
  border: 1px solid #c9ccd2;
  margin: 0 1px 1px;
  min-height: 216px;
}

.tab-con-content {
  margin: 11px 8px;
}



.row-input .w-input {
  width: 200px;
}

.input-date-picker .v-text-field .v-input__append-inner{
      padding: 4px;
}

.description .ms-textarea {
  min-height: 190px;
}

/**Footer Dialog */
.ms-popup-footer {
  /* padding-right: 11px; */
}

.divide {
  width: 100%;
  border-top: 1px solid #e0e0e0;
  margin: 32px 0 20px 0;
  position: relative;
}

.ms-button-size-default {
  height: 36px;
  padding: 8px 20px;
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

.ms-button-primary {
  border: 1px solid transparent;
  color: #fff;
  background-color: #2ca01c;
}

.ms-button-primary:focus {
  background-color: #2ca01c;
  color: #fff;
}

.ms-button-primary:hover {
  background-color: #35bf22;
  color: #fff;
}

.ms-button-primary:active {
  background-color: #248b15;
  color: #fff;
}

.ms-button-radius-false,
.ms-button-radius-false:before {
  border-radius: 3px;
}

/**Dialog cảnh báo */
#error-dialog {
  display: none;
}

.con-ms-message-box {
  transition: all 0.2s;
  width: 100%;
  height: 100%;
  position: fixed;
  left: 0;
  top: 0;
  z-index: 20000;
  opacity: 1;
}

.message-center {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  height: 100%;
}

.ms-message-bg {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: absolute;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 10;
  transition: all 0.25s ease;
  opacity: 1;
}

.drag-it-dude {
  position: absolute;
  z-index: 100;
}

.ms-mesage-box {
  position: relative;
  transition: all 0.2s;
  z-index: 100;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  background: #fff;
  -webkit-animation: rebound-data-v-b33a4368 0.3s;
  animation: rebound-data-v-b33a4368 0.3s;
  border-radius: 3px;
}

.mi-exclamation-error-48-2 {
  background-position: -24px -954px;
}

.Center {
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
}

/* Alert */
.alert {
  position: absolute !important;
  top: 28px;
  /* left: 50%; */
  right: 0;
  z-index: 2000;
  display: none;

  -webkit-transform: translate(-50%, -50%);
  -moz-transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  -o-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}

.close-alert-btn {
  margin-left: 16px;
  margin-top: -2px;
}
</style>

<style scoped>
/**Css table */
/*tab tài khoản ngân hàng*/
.tab-content .grid-model-control {
  overflow: auto;
  max-height: 158px;
}

.grid-model-control {
  min-width: 100%;
}

.gridComponent {
  position: relative;
  min-width: 100%;
}

.dynamic-table {
  flex: 1;
}

.table-scroll {
  overflow: auto;
  margin-top: 0;
}

.table-scroll,
.table-scroll table {
  min-width: 100%;
}

.table-scroll table {
  margin: auto;
  border-spacing: 0;
  border-collapse: separate;
}

.table-scroll th {
  min-height: 34px;
}

.table-scroll td {
  height: 40px;
  position: relative;
}

.table-scroll td,
.table-scroll th {
  background-color: #fff;
  padding: 4px 10px;
  border-bottom: 1.2px solid #c7c7c7;
  border-left: 1px dotted #c7c7c7;
}

.table-scroll thead tr th {
  text-transform: uppercase;
  border-left: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  font-size: 12px;
}

.table-scroll td:first-child,
.table-scroll th:first-child {
  border-left: 0 !important;
}

.table-scroll thead tr:first-child th {
  background: #eceef1;
  top: 0;
  z-index: 4;
  position: relative;
}

.table-scroll thead tr:first-child th.dynamic-header,
.table-scroll thead tr:first-child th.static-header {
  position: sticky;
}

.th-height {
  height: inherit;
  padding: 8px 0;
  align-items: center;
}

.padding-th {
  padding: 0 20px 0 10px;
}

.th-table {
  display: flex;
  align-items: center;
  text-transform: uppercase !important;
}

.th-table span {
  text-transform: uppercase !important;
  flex: 1;
  min-height: 0;
  min-width: 0;
}

.table-scroll tbody tr {
  font-size: 13px;
}

.table-scroll tbody .select-row .td {
  background: #f4f5f8 !important;
}

.table-scroll tbody tr:hover .ms-table--td {
  background: #f3f8f8 !important;
}

.tab-content .grid-control-item {
  padding: 0 !important;
}

.grid-control-item {
  width: 100%;
  position: sticky;
  bottom: 0;
  background-color: #fff;
}

.tab-content .grid-control-item .btn-grid-control {
  padding: 10px 0 0 0 !important;
}

.grid-control-item .btn-grid-control button {
  background: #fff;
  border: 1px solid #8d9096;
  border-radius: 3px !important;
  padding: 2px 20px !important;
  margin-right: 10px;
  font-weight: 700;
}

.ms-button-size-small {
  height: 24px;
  padding: 1px 20px 3px;
}

.top-grid {
  display: flex;
  border-bottom: 2px solid #d3d6db;
  place-items: center;
}

.top-grid .address-combo {
  padding-left: 18px;
  padding-bottom: 6px;
}

.tab-content .grid-address {
  max-height: 131px;
}

.tab-content .grid-address .ms-table--thead {
  display: none;
}
</style>
