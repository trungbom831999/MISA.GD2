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
                  class="ms-component ms-button ms-button-secondary ms-con-dropdown-radius-true-true ms-padding-is-single-true-size-default expand-more-button ms-button-size-default mr-3"
                >
                  <div class="ms-button-text ms-button--text flex align-center">
                    <span class="pr-1">Chuyển tài khoản hạch toán</span>
                  </div>
                </button>
                <button
                  name="button"
                  class="ms-component ms-button ms-button-size-default ms-button-primary ms-button-radius-true ms-dropdown-style-default"
                  @click="showPopup()"
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
                    class="icon-inputx notranslate ms-input--icon icon-after mi-search mi mi-16"
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
                      style="min-width: 100px; top: 93px"
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
                    {{ account.accountNumber }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountName }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountNature }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountNameInEnglish }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.description }}
                  </td>
                  <td class="ms-td-viewer text-left">
                    {{ account.accountStatus }}
                  </td>
                  <td class="ms-td-viewer ms-td-wiget text-right">
                    <div class="flex justify-end">
                      <div class="ms-dropdown">
                        <button
                          class="ms-button edit-btn"
                          data-toggle="modal"
                          data-target="#add-supplier-dialog"
                        >
                          <div class="ms-button-text flex align-center">
                            Sửa
                          </div>
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
            <div class="ms-pagination">
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

    <add-account-dialog @closePopup="closePopup" :isShowPopup="isShowPopup"></add-account-dialog>
  </div>
</template>
<script>
import AddAccountDialog from "../account/AddAccountDialog.vue";

export default {
  components: {
    AddAccountDialog
  },
  data() {
    return { 
      loading: false,
      isShowPopup: false,
      accounts: [
        {
          accountNumber: "123456",
          accountName: "Tiền Việt",
          accountNature: "Dư nợ",
          accountNameInEnglish: "Vietnam dong",
          description: "Tiền VND Polime",
          accountStatus: "Đang sử dụng",
        },
        {
          accountNumber: "123456",
          accountName: "Tiền Mỹ",
          accountNature: "Dư nợ",
          accountNameInEnglish: "Vietnam dong",
          description: "Tiền VND Polime",
          accountStatus: "Đang sử dụng",
        },
        {
          accountNumber: "123456",
          accountName: "Tiền Ảo",
          accountNature: "Dư nợ",
          accountNameInEnglish: "Vietnam dong",
          description: "Tiền VND Polime",
          accountStatus: "Đang sử dụng",
        },
        {
          accountNumber: "123456",
          accountName: "Bitcoin",
          accountNature: "Dư nợ",
          accountNameInEnglish: "Vietnam dong",
          description: "Tiền VND Polime",
          accountStatus: "Đang sử dụng",
        },
      ],
    };
  },
  methods:{
    showPopup(){
      this.isShowPopup = true;
    },

    closePopup(value) {
      this.isShowPopup = value;
    }
  }
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