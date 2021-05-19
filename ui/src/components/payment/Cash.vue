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

              <div class="add-btn ms-dropdown">
                <button
                  name="button"
                  class="ms-component ms-button ms-button-size-default ms-button-primary ms-radius-true ms-dropdown-style-default"
                  data-toggle="modal"
                  data-target="#add-supplier-dialog"
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
                      class="ms-component ms-button ms-padding-is-single-false-size-default ms-con-dropdown-radius-false-true ms-padding-is-single-false-size-default ms-button-primary"
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
                      class="ms-component ms-dropdown-item-secondary-false ms-dropdown--item"
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
    </div>
    <payment
      @closePaymentPopup="closePaymentPopup"
      :isShowPopup="isShowPaymentPopup"
    ></payment>
  </div>
</template>

<script>
import DropdownButton from "../baseControl/DropdownButton.vue";
import Payment from "./Payment.vue";

export default {
  name: "Cash",
  components: {
    DropdownButton,
    Payment,
  },
  data() {
    return {
      isShowPaymentPopup: true,
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
