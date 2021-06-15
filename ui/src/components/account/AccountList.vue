<template>
  <div class="content-area__content">
    <div class="body body-di">
      <!-- Phần thêm nhà cung cấp  -->
      <div class="title-distance lock-title-distance">
        <div class="header-di">
          <div class="title-di">Hệ thống tài khoản</div>
          <div class="header-di">
            <div class="header-button">
              <div class="flex">
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
                    mr-3
                  "
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    <span class="pr-1">Chuyển tài khoản hạch toán</span>
                  </div>
                </button>
                <button
                  name="button"
                  class="
                    ms-component
                    ms-button
                    ms-button-size-default
                    ms-button-primary
                    ms-button-radius-true
                    ms-dropdown-style-default
                  "
                  @click="showPopup(),setIsEditFalse(),(idAccount = '')"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    Thêm
                  </div>
                </button>
              </div>
            </div>
          </div>
        </div>
        <div class="back flex justify back-all-di">
          <div class="mi mi-16 mi-chevron-left--primary"></div>
          <a href="#">Tất cả danh mục</a>
        </div>
      </div>

      <!-- Lọc và tìm kiếm -->
      <div class="grid-list-data sticky left-0">
        <div class="grid-button-list flex">
          <div class="w-6/7 flex">
            <div class="content-input-list">
              <div class="ms-input">
                <div
                  class="ms-component ms-con-input-label ms-input style-label"
                >
                  <input
                    id="input-search-supplier"
                    class="input-search hasIcon"
                    type="text"
                    placeholder="Tìm kiếm theo số, tên tài khoản"
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
            </div>
          </div>

          <div class="w-1/7">
            <div class="ultility-buttons flex">
              <div class="tiltle-Collapse-expand">
                <div>Thu gọn</div>
              </div>
              <div class="refresh-button list-button" title="Làm mới bộ lọc">
                <div class="mi mi-24 mi-refresh"></div>
              </div>
              <div class="print-button list-button" title="Nhập từ Excel">
                <div class="mi mi-24 mi-excel__nav"></div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="grid flex bg-white">
        <div class="grid-model-control">
          <div class="ms-grid-viewer table-scroll table-area" outsize="30px">
            <table v-show="!loading" class="ms-table-viewer">
              <thead class="ms-thead-viewer">
                <tr class="ms-tr-viewer">
                  <th class="ms-out-left-white-16"></th>
                  <div class="dis-contents ms-tbody-viewer">
                    <th class="ms-th-viewer dymamic-col header w-130">
                      <span class="ms-head-title flex justify-left"
                        >Số tài khoản
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Tên tài khoản
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-100">
                      <span class="ms-head-title flex justify-left"
                        >Tính chất
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-250">
                      <span class="ms-head-title flex justify-left"
                        >Tên tiếng anh
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th
                      class="ms-th-viewer dymamic-col header"
                      style="min-width: 250px; top: 93px"
                    >
                      <span class="ms-head-title flex justify-left"
                        >Diễn giải
                        <div class="mi mi-16" style="display: none"></div>
                      </span>
                      <div
                        class="mi mi-16 icon-head mi-header-option"
                        style="display: none"
                      ></div>
                    </th>

                    <th class="ms-th-viewer dymamic-col header w-120">
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
                  v-for="(account, index) in accounts"
                  :key="index"
                >
                  <td class="ms-out-left-white-16"></td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountnumber }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountname }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.natureaccount }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountnameinenglish }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.description }}
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
                              (idAccount = account.idaccount)
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
                                  (idAccountDelete = account.idaccount),
                                    showDeleteDialog(account.accountnumber)
                                "
                                >Xóa
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
            <div class="ms-pagination" style="width: 1357px">
              <div
                class="flex items-center justify-between w-full pagination-bar"
              >
                <div class="left-pagination">
                  <div class="total-record">
                    Tổng số: <b>{{ accounts.length }}</b> bản ghi
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

    <!-- dialog xóa  -->
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
                      @click="deleteAccount()"
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
    <add-account-dialog
      @closePopup="closePopup"
      :isShowPopup="isShowPopup"
      @loadData="loadData"
      :idAccount="idAccount"
    ></add-account-dialog>
  </div>
</template>
<script>
var localhost = "https://localhost:44350/api/Accounts/";

import AddAccountDialog from "../account/AddAccountDialog.vue";
import DropdownButton from "../baseControl/DropdownButton.vue";
import EventBus from "../../main.js";

import * as axios from "axios";

export default {
  components: {
    AddAccountDialog,
    DropdownButton,
  },
  data() {
    return {
      loading: false,
      isShowPopup: false,
      accounts: [],
      idAccount: "",
      idAccountDelete: "",
    };
  },
  methods: {
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

    //load dữ liệu
    async loadData() {
      this.loading = true;
      const response = await axios.get(localhost);

      console.log(response.data);
      this.loading = false;
      this.accounts = response.data;

      this.idSupplier = "";
    },

    //dialog xóa
    showDeleteDialog(accountnumber) {
      console.log(accountnumber);
      document.getElementById("idMessageDelete").innerHTML =
        "Bạn có thực sự muốn xóa Tài khoản < " + accountnumber + " > không?";
      document.getElementById("delete-dialog").style.display = "block";
    },

    hideDeleteDialog() {
      document.getElementById("delete-dialog").style.display = "none";
    },

    //xóa tài khoản
    async deleteAccount() {
      let m = this;
      await axios({
        method: "delete",
        url: localhost + this.idAccountDelete,
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
  },
  created() {
    this.loadData();
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
.ms-button-radius-true,
.ms-button-radius-true:before {
  border-radius: 30px;
}

.content-input-list {
  width: 250px;
  float: left;
  margin-right: 10px;
}

.tiltle-Collapse-expand {
  font-size: 13px;
  color: #0075c0;
  margin-top: 3px;
  margin-right: 12px;
  cursor: pointer;
}
</style>