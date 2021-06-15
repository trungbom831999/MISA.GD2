<template>
  <div class="ms-popup">
    <div
      class="ms-component con-ms-popup ms-popup-is-right"
      :style="[!isShowPopup ? { display: 'none' } : { display: 'block' }]"
      @keyup.esc="$emit('closePopup', false)"
      tabindex="0"
    >
      <div class="ms-popup--background"></div>
      <div
        class="ms-popup ms-popup-content ms-popup-is-right"
        style="min-width: 800px; max-width: 800px; width: 800px"
        :style="[
          extendPopup
            ? {
                'min-width': 'calc(100vw - 6px)',
                'max-width': 'calc(100vw - 6px)',
                width: 'calc(100vw - 6px)',
                height: '100%',
              }
            : { 'min-width': '800px', 'max-width': '800px', width: '800px' },
        ]"
      >
        <header class="ms-popup--header">
          <div class="ms-popup--title ms-popup-title-right">
            <h2 class="title-di">Thêm Tài khoản</h2>
          </div>

          <div class="ms-popup-close">
            <div
              class="mi mi-24 mi-help mr-6-px help-btn"
              title="Trợ giúp"
            ></div>
            <div
              class="mi mi-24 mi-close"
              title="Đóng (ESC)"
              @click="closePopup()"
            ></div>
          </div>
        </header>

        <div class="ms-popup--content ms-popup-content-right">
          <div class="right-popup-content">
            <div class="basic-information">
              <div class="row-input"></div>
              <div class="flex row-input w-1/4 p-r-12">
                <ms-input
                  label="Số tài khoản"
                  required
                  ref="inputAccountNumber"
                  v-model="account.accountnumber"
                  :error="
                    (account.accountnumber ? false : true) && mustValidate
                  "
                ></ms-input>
              </div>

              <div class="flex row-input w-full">
                <div class="w-1/2 p-r-12">
                  <ms-input
                    label="Tên tài khoản"
                    required
                    ref="inputAccountName"
                    v-model="account.accountname"
                    :error="
                    (account.accountname ? false : true) && mustValidate
                  "
                  ></ms-input>
                </div>
                <div class="w-1/2">
                  <ms-input
                    label="Tên tiếng Anh"
                    v-model="account.accountnameinenglish"
                  ></ms-input>
                </div>
              </div>

              <div class="flex row-input w-full">
                <div class="w-1/4 p-r-12">
                  <select-auto-complete-menu-table
                    label="Tài khoản tổng hợp"
                    :column="colGeneralAccount"
                    :items="generalAccounts"
                    mainItem="accountNumber"
                    v-model="account.generalaccountnumber"
                  ></select-auto-complete-menu-table>
                </div>
                <div class="w-1/4 p-r-12">
                  <select-auto-complete
                    label="Tính chất"
                    :items="natureAccounts"
                    :itemDefault="0"
                    required
                    v-model="account.natureaccount"
                  ></select-auto-complete>
                </div>
              </div>

              <div class="row-input w-full">
                <ms-textarea
                  label="Diễn giải"
                  maxlength="255"
                  rows="2"
                  v-model="account.description"
                ></ms-textarea>
              </div>

              <div class="w-full mb-5">
                <check-box
                  label="Có hạch toán ngoại tệ"
                  v-model="account.isaccountexception"
                ></check-box>
              </div>
            </div>

            <div class="w-full ms-collapse-infomation">
              <div class="ms-collapse default">
                <div
                  class="ms-collapse-item primary-collapse"
                  :class="{ 'open-item': openInfomation }"
                >
                  <a
                    class="ms-collapse-item--header"
                    @click="changeHeightInfomation()"
                  >
                    <span
                      class="
                        icon-header
                        ms-collapse-item--icon-header
                        primary-collapse--icon
                      "
                    >
                      <div class="mi-arrow-right--black mi mi-16"></div>
                    </span>
                    <div class="ms-collapse-item--label">
                      <div>Theo dõi chi tiết theo</div>
                    </div>
                  </a>

                  <div
                    class="ms-collapse-item--content"
                    :style="[
                      openInfomation
                        ? { 'max-height': '230px' }
                        : { 'max-height': '0px' },
                    ]"
                  >
                    <div class="con-content--item">
                      <div class="content-drop-section w-full">
                        <div class="w-full row-input flex">
                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Đối tượng"
                                  v-model="editableObjectDefault"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="objectDefaults"
                                  :disabled="!editableObjectDefault"
                                  v-model="account.accountobjectdefault"
                                ></ms-select>
                              </div>
                            </div>
                          </div>

                          <div class="w-1/2 flex">
                            <div class="w-5/6 flex align-center">
                              <div class="w-full">
                                <check-box
                                  label="Tài khoản ngân hàng"
                                  v-model="account.hasbankaccount"
                                ></check-box>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="w-full row-input flex">
                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Đối tượng THCP"
                                  v-model="editableObjectTHCP"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="objectTHCPs"
                                  :disabled="!editableObjectTHCP"
                                  v-model="account.accountobjectthcp"
                                ></ms-select>
                              </div>
                            </div>
                          </div>

                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Công trình"
                                  v-model="editableConstruction"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="constructions"
                                  :disabled="!editableConstruction"
                                  v-model="account.accountconstruction"
                                ></ms-select>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="w-full row-input flex">
                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Đơn đặt hàng"
                                  v-model="editableOrder"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="orders"
                                  :disabled="!editableOrder"
                                  v-model="account.accountorder"
                                ></ms-select>
                              </div>
                            </div>
                          </div>

                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Hợp đồng bán"
                                  v-model="editableSaleContract"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="saleContracts"
                                  :disabled="!editableSaleContract"
                                  v-model="account.accountsalecontract"
                                ></ms-select>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="w-full row-input flex">
                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Hợp đồng mua"
                                  v-model="editablePurchaseContract"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="purchaseContracts"
                                  :disabled="!editablePurchaseContract"
                                  v-model="account.accountpurchasecontract"
                                ></ms-select>
                              </div>
                            </div>
                          </div>

                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Khoản mục CP"
                                  v-model="editableItemCP"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="itemCPs"
                                  :disabled="!editableItemCP"
                                  v-model="account.accountitemcp"
                                ></ms-select>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="w-full row-input flex">
                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Đơn vị"
                                  v-model="editableUnit"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="units"
                                  :disabled="!editableUnit"
                                  v-model="account.accountunit"
                                ></ms-select>
                              </div>
                            </div>
                          </div>

                          <div class="w-1/2">
                            <div class="w-5/6 flex align-center">
                              <div class="w-1/2">
                                <check-box
                                  label="Mã thống kê"
                                  v-model="editableStatisticalCode"
                                ></check-box>
                              </div>
                              <div class="w-1/2">
                                <ms-select
                                  :items="statisticalCode"
                                  :disabled="!editableStatisticalCode"
                                  v-model="account.accountstatisticalcode"
                                ></ms-select>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="ms-popup-footer">
          <div class="divide-is-right"></div>
          <div class="ms-popup-footer-content ms-popup-footer-content-right">
            <div class="flex footer-button-group">
              <div class="w-full flex align-right">
                <div class="flex align-right">
                  <div class="p-x-3">
                    <button
                      class="
                        ms-button-size-default
                        ms-button-secondary
                        ms-button-radius-false
                        ms-button
                      "
                      @click="saveAccount()"
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
                      class="
                        ms-button-size-default
                        ms-button-primary
                        ms-button-radius-false
                        ms-button
                      "
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
                  class="
                    ms-button-size-default
                    ms-button-secondary
                    ms-button-radius-false
                    ms-button
                  "
                  @click="closePopup()"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Hủy
                  </div>
                </button>
              </div>
            </div>
          </div>
        </div>

        <div
          class="resize flex"
          :class="[
            extendPopup ? 'is-full-screen-true' : 'is-full-screen-false',
          ]"
          @click="changeSizePopup()"
        >
          <div
            class="mi mi-chevron-left"
            style="width: 9px; height: 14px"
          ></div>
        </div>
      </div>
    </div>

    <!-- thông báo lỗi  -->

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
                      class="
                        ms-component
                        ms-button
                        ms-button-size-default
                        ms-button-primary
                        ms-button-primary-disabled-false
                        ms-button-radius-false
                        ms-button
                      "
                      @click="hideErrorDialog()"
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
var localhost = "https://localhost:44350/api/Accounts/";

import MsInput from "../baseControl/MsInput.vue";
import MsTextarea from "../baseControl/MsTextarea.vue";
import MsSelect from "../baseControl/MsSelect";
import CheckBox from "../baseControl/CheckBox.vue";
import SelectAutoComplete from "../baseControl/SelectAutoComplete.vue";
import SelectAutoCompleteMenuTable from "../baseControl/SelectAutoCompleteMenuTable.vue";
import EventBus from "../../main.js";

import * as axios from "axios";
export default {
  components: {
    MsInput,
    MsTextarea,
    MsSelect,
    CheckBox,
    SelectAutoComplete,
    SelectAutoCompleteMenuTable,
  },
  props: {
    isShowPopup: {
      type: Boolean,
      default: false,
    },
    idAccount: {
      type: String,
      default: "",
    },
  },
  watch: {
    isShowPopup(newV) {
      if (newV) {
        var m = this;
        setTimeout(function () {
          if (m.idAccount) {
            m.getAccount(m.idAccount);
          } else {
            m.resetInfoAccount();
          }
          m.focusInput("inputAccountNumber");
          m.mustValidate = false;
        }, 100);
      }
      // console.log(oldV);
    },
    idAccount(newV, oldV) {
      var m = this;
      if (newV) {
        setTimeout(function () {
          m.getAccount(newV);
          m.mustValidate = false;
        }, 100);
      } else {
        setTimeout(function () {
          m.resetInfoAccount();
          m.mustValidate = false;
        }, 100);
      }
      console.log(newV);
      console.log(oldV);
    },
  },
  data() {
    return {
      isEdit: false,
      mustValidate: false,
      inputFocus: "",
      account: {
        accountconstruction: "Chỉ cảnh báo",
        accountitemcp: "Chỉ cảnh báo",
        accountname: "",
        accountnameinenglish: "",
        accountnumber: "",
        accountobjectdefault: "Nhà cung cấp",
        accountobjectthcp: "Chỉ cảnh báo",
        accountorder: "Chỉ cảnh báo",
        accountpurchasecontract: "Chỉ cảnh báo",
        accountsalecontract: "Chỉ cảnh báo",
        accountstatisticalcode: "Chỉ cảnh báo",
        accountunit: "Chỉ cảnh báo",
        description: "",
        generalaccountnumber: "",
        hasbankaccount: false,
        idaccount: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        isaccountexception: false,
        natureaccount: "Dư nợ",
      },
      colGeneralAccount: [
        { name: "Số tài khoản", width: "120" },
        { name: "Tên tài khoản", width: "250" },
      ],

      generalAccounts: [
        {
          accountNumber: "112",
          accountName: "Tiền Việt",
        },
        {
          accountNumber: "234",
          accountName: "Tiền Mỹ",
        },
        {
          accountNumber: "345",
          accountName: "Bitcoin",
        },
      ],

      natureAccounts: ["Dư nợ", "Dư có", "Lưỡng tính", "Không có số dư"],

      editableObjectDefault: false,
      objectDefaults: ["Nhà cung cấp", "Khách hàng", "Nhân viên"],
      editableObjectTHCP: false,
      objectTHCPs: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableConstruction: false,
      constructions: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableOrder: false,
      orders: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableSaleContract: false,
      saleContracts: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editablePurchaseContract: false,
      purchaseContracts: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableItemCP: false,
      itemCPs: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableUnit: false,
      units: ["Chỉ cảnh báo", "Bắt buộc nhập"],
      editableStatisticalCode: false,
      statisticalCode: ["Chỉ cảnh báo", "Bắt buộc nhập"],

      openInfomation: true,
      extendPopup: false,
    };
  },
  methods: {
    changeHeightInfomation() {
      if (this.openInfomation == true) {
        this.openInfomation = false;
      } else {
        this.openInfomation = true;
      }
    },

    changeSizePopup() {
      if (this.extendPopup == true) {
        this.extendPopup = false;
      } else {
        this.extendPopup = true;
      }
    },

    closePopup() {
      this.$emit("closePopup", false);
    },

    loadData() {
      this.$emit("loadData");
    },

    focusInput(refInput) {
      this.$refs[refInput].focusInput();
    },

    showErrorDialog(content) {
      document.getElementById("idMessageError").innerHTML = content;
      document.getElementById("error-dialog").style.display = "block";
    },

    hideErrorDialog() {
      document.getElementById("error-dialog").style.display = "none";
      // document.getElementById(this.inputFocus).focus();
      this.focusInput(this.inputFocus);
    },

    //reset thông tin tài khoản
    resetInfoAccount() {
      this.mustValidate = false;
      this.inputFocus = "";
      this.isEdit = false;

      this.account = {
        accountconstruction: "Chỉ cảnh báo",
        accountitemcp: "Chỉ cảnh báo",
        accountname: "",
        accountnameinenglish: "",
        accountnumber: "",
        accountobjectdefault: "Nhà cung cấp",
        accountobjectthcp: "Chỉ cảnh báo",
        accountorder: "Chỉ cảnh báo",
        accountpurchasecontract: "Chỉ cảnh báo",
        accountsalecontract: "Chỉ cảnh báo",
        accountstatisticalcode: "Chỉ cảnh báo",
        accountunit: "Chỉ cảnh báo",
        description: "",
        generalaccountnumber: "",
        hasbankaccount: false,
        idaccount: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        isaccountexception: false,
        natureaccount: "Dư nợ",
      };
      this.editableObjectDefault = false;
      this.editableObjectTHCP = false;
      this.editableConstruction = false;
      this.editableOrder = false;
      this.editableSaleContract = false;
      this.editablePurchaseContract = false;
      this.editableItemCP = false;
      this.editableUnit = false;
      this.editableStatisticalCode = false;
    },

    //validate
    checkInfoAccount() {
      if (this.account.accountnumber.trim() == "") {
        this.showErrorDialog("Số tài khoản không được để trống");
        this.mustValidate = true;
        this.inputFocus = "inputAccountNumber";
        return false;
      } else if (this.account.accountname.trim() == "") {
        this.showErrorDialog("Tên tài khoản không được để trống");
        this.mustValidate = true;
        this.inputFocus = "inputAccountName";
        return false;
      } else {
        return true;
      }
    },

    //kiểm tra các checkbox trong theo dõi chi tiết
    checkCheckBox() {
      if (this.editableObjectDefault == false) {
        this.account.accountobjectdefault = "";
      }

      if (this.editableObjectTHCP == false) {
        this.account.accountobjectthcp = "";
      }

      if (this.editableConstruction == false) {
        this.account.accountconstruction = "";
      }

      if (this.editableOrder == false) {
        this.account.accountorder = "";
      }

      if (this.editableSaleContract == false) {
        this.account.accountsalecontract = "";
      }

      if (this.editablePurchaseContract == false) {
        this.account.accountpurchasecontract = "";
      }

      if (this.editableItemCP == false) {
        this.account.accountitemcp = "";
      }

      if (this.editableUnit == false) {
        this.account.accountunit = "";
      }

      if (this.editableStatisticalCode == false) {
        this.account.accountstatisticalcode = "";
      }
    },

    //lấy dữ liệu tài khoản
    async getAccount(id) {
      let m = this;
      axios({
        method: "get",
        url: localhost + id,
      })
        .then(function (response) {
          //thành công
          console.log(response.data);
          m.account = response.data;
          if (response.data.accountobjectdefault != "") {
            m.editableObjectDefault = true;
          } else {
            m.editableObjectDefault = false;
          }

          if (response.data.accountobjectthcp != "") {
            m.editableObjectTHCP = true;
          } else {
            m.editableObjectTHCP = false;
          }

          if (response.data.accountconstruction != "") {
            m.editableConstruction = true;
          } else {
            m.editableConstruction = false;
          }

          if (response.data.accountorder != "") {
            m.editableOrder = true;
          } else {
            m.editableOrder = false;
          }

          if (response.data.accountsalecontract != "") {
            m.editableSaleContract = true;
          } else {
            m.editableSaleContract = false;
          }

          if (response.data.accountpurchasecontract != "") {
            m.editablePurchaseContract = true;
          } else {
            m.editablePurchaseContract = false;
          }

          if (response.data.accountitemcp != "") {
            m.editableItemCP = true;
          } else {
            m.editableItemCP = false;
          }

          if (response.data.accountunit != "") {
            m.editableUnit = true;
          } else {
            m.editableUnit = false;
          }

          if (response.data.accountstatisticalcode != "") {
            m.editableStatisticalCode = true;
          } else {
            m.editableStatisticalCode = false;
          }
          m.focusInput("inputAccountNumber");
        })
        .catch(function (error) {
          //gặp lỗi
          console.log(error);
        });
    },

    //ấn nút CẤT
    saveAccount() {
      if (this.checkInfoAccount()) {
        if (this.isEdit) {
          this.editAccount();
        } else {
          this.addAccount();
        }
      }
    },

    //sửa
    editAccount() {
      this.checkCheckBox();
      console.log(this.account);
      var m = this;
      axios({
        method: "put",
        url: localhost + this.idAccount,
        data: this.account,
      })
        .then(function (response) {
          //thành công
          console.log(response);
          m.resetInfoAccount();
          m.closePopup();
          m.loadData();
        })
        .catch(function (error) {
          //gặp lỗi
          var noti = error.response.data;
          m.showErrorDialog(noti.userMsg);
          if (noti.errorCode == "misa-001") {
            m.inputFocus = "inputAccountNumber";
          }
        });
    },

    //thêm mới
    addAccount() {
      this.checkCheckBox();
      console.log(this.account);
      var m = this;
      axios({
        method: "post",
        url: localhost,
        data: this.account,
      })
        .then(function (response) {
          //thành công
          console.log(response);
          m.resetInfoAccount();
          m.closePopup();
          m.loadData();
        })
        .catch(function (error) {
          //gặp lỗi
          var noti = error.response.data;
          m.showErrorDialog(noti.userMsg);
          if (noti.errorCode == "misa-001") {
            m.inputFocus = "inputAccountNumber";
          }
        });
    },
  },
  created() {
    EventBus.$on("setIsEdit", (data) => (this.isEdit = data));
  },
};
</script>
<style>
.ms-popup {
  position: relative;
  transition: all 0.2s;
  z-index: 200;
  max-width: calc(100% - 30px);
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  display: flex;
  flex-direction: column;
  background: #fff;
}

.con-ms-popup {
  transition: all 0.2s;
  width: 100%;
  height: 100%;
  position: fixed;
  left: 100px;
  top: 100px;
  left: 0;
  top: 0;
  z-index: 999;
  display: flex;
  align-items: center;
  justify-content: center;
  opacity: 1;
  z-index: 200;
}

.ms-popup--background {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: fixed;
  left: 0;
  top: 0;
  height: 100%;
  z-index: 98;
  transition: all 0.25s ease;
  opacity: 1;
}

.ms-popup-content {
  position: relative;
}

.ms-popup-is-right {
  justify-content: flex-end;
  height: 100%;
  right: 0;
  left: auto;
  width: auto;
}

/**header popup */
.ms-popup--header {
  width: 100%;
  display: flex;
  justify-content: space-between;
  border-radius: 5px 5px;
  position: relative;
}

.ms-popup--title {
  width: 100%;
  padding: 20px 32px;
  padding-right: 12px;
  position: relative;
  overflow: hidden;
  border-radius: 5px 5px 0 0;
}

.ms-popup--title.ms-popup-title-right {
  padding: 14px 16px 24px;
}

.title-di {
  font-size: 24px;
  font-weight: 600;
  color: #212121;
}

/**content popup */
.ms-popup--content {
  transition: all 0.23s ease 0.1s;
  flex-direction: column;
  display: flex;
  overflow: auto;
  overflow-y: visible;
  padding: 0 32px 20px;
}

.ms-popup--content.ms-popup-content-right {
  padding: 0 16px 16px;
  overflow-y: auto;
  display: flex;
  flex-direction: column;
  flex: 1;
  min-height: 0;
  min-width: 0;
}

.ms-collapse {
  transition: all 0.3s ease;
  cursor: pointer;
  border-radius: 8px;
  width: 100%;
}

.ms-collapse-item:last-child {
  border-bottom: 0 solid transparent;
}

.ms-collapse-item {
  transition: all 0.2s ease-out;
}

.ms-collapse-item--header {
  font-size: 18px;
  display: block;
  padding: 10px;
  position: relative;
  transition: all 0.2s ease-out;
  color: inherit;
  padding-left: 14px;
  color: #000 !important;
}

.ms-collapse-item:hover .ms-collapse-item--header {
  color: #2ca01c !important;
}

.ms-collapse-item--icon-header {
  left: 4px;
  transform: translate(-50%, -50%);
}

.ms-collapse-item--icon-header,
.ms-collapse-secondary-item--icon-header {
  position: absolute;
  top: 50%;
  display: block;
  transition: all 0.2s ease-out;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 5px;
}

.ms-collapse.default .open-item .ms-collapse-item--icon-header {
  transform: translate(-50%, -50%) rotate(90deg);
}

.ms-collapse-item--label {
  font-size: 16px;
}

.ms-collapse-item--content {
  overflow: hidden;
  transition: all 0.2s ease-out;
}

.open-item .ms-collapse-item--content {
  padding-top: 1px;
  overflow: hidden;
}

.con-content--item {
  font-size: 1rem;
  padding: 5px 10px 10px;
  opacity: 1;
  transition: all 0.2s ease-out;
}

.ms-collapse.default .open-item .con-content--item {
  opacity: 1;
}

/**footer popup */
.divide-is-right {
  height: 4px;
  background: #f4f5f8;
  width: 100%;
}

.ms-popup-footer-content-right {
  padding: 16px;
}

/**nút mở rộng popup */
.is-full-screen-false {
  transform: rotateY(0deg);
}

.is-full-screen-true {
  transform: rotateY(180deg);
}

.resize {
  width: 12px;
  height: 50px;
  background: #fff;
  border: 1px solid #d4d7dc;
  border-radius: 8px;
  position: absolute;
  align-items: center;
  left: -6px;
  top: 43%;
  resize: both !important;
}
</style>
