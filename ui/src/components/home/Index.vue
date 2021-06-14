<template>
  <div class="navigation-tabs">
    <div class="ms-tabs con-ms-tabs ms-tabs-position-top">
      <div class="con-ms-ul-tabs flex">
        <ul class="ul-tabs ms-tabs-ul ms-ul-tabs-left">
          <li class="ms-tabs-li flex active-item">
            <div class="ms-tabs-btn">
              <div class="ms-label tab-label">Quy trình</div>
            </div>
          </li>
          <li class="ms-tabs-li flex">
            <div class="ms-tabs-btn">
              <div class="ms-label tab-label">Thu chi tiền</div>
            </div>
          </li>
        </ul>
        <span class="line-ms-tabs line-bottom"></span>
      </div>
    </div>

    <div class="form-process flex scroller">
      <div class="vertical-center flex">
        <div class="process-and-utility-area">
          <div class="process-area">
            <div class="title">Nghiệp vụ tiền mặt</div>
            <div class="content-area">
              <div class="content">
                <div class="mi-h-340 mi-process-cash"></div>

                <div class="div-face-button hoverable receive">
                  <div class="title-button">Thu tiền</div>
                </div>
                <router-link to="/cash" title="Phiếu chi" style="color: #000">
                  <div class="div-face-button hoverable payment">
                    <div class="title-button">Chi tiền</div>
                  </div>
                </router-link>

                <div class="div-face-button hoverable audit">
                  <div class="title-button">Kiểm kê quỹ</div>
                </div>
              </div>
            </div>
          </div>

          <div class="dictionary-area flex w-full">
            <router-link
              to="/supplier"
              title="Nhà cung cấp"
              class="dictionary-item hoverable w-1/4"
              style="color: #000"
            >
              <div class="dictionary-content">
                <div class="logo mi mi-24 mi-process-provider"></div>
                <div class="text">Nhà cung cấp</div>
              </div>
            </router-link>

            <router-link
              to="/account"
              title="Hệ thống tài khoản"
              class="dictionary-item hoverable w-1/4"
              style="color: #000"
            >
              <div class="dictionary-content">
                <div class="logo mi mi-24 mi-process-customer"></div>
                <div class="text">Hệ thống tài khoản</div>
              </div>
            </router-link>
          </div>
        </div>

        <div class="report-area">
          <div class="title">Báo cáo</div>
          <div class="favorite-report">
            <ul>
              <li>Bảng kê số dư tiền theo ngày</li>
              <li>S03a1-DN: Sổ nhật ký thu tiền</li>
              <li>S03a2-DN: Sổ nhật ký chi tiền</li>
              <li>Sổ kế toán chi tiết quỹ tiền mặt</li>
            </ul>
          </div>
          <div class="footer">
Tất cả báo cáo
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* nav tab  */
.navigation-tabs {
  position: relative;
}

.ms-tabs-position-top {
  position: sticky;
  width: 100%;
}

.con-ms-tabs {
  overflow: hidden;
  background: #f4f5f8;
  z-index: 0;
}

.con-ms-tabs .con-ms-ul-tabs {
  position: relative;
}

.ms-tabs-position-top .con-ms-ul-tabs .ms-tabs-ul {
  width: 100%;
  height: 100%;
  padding-left: 0;
  position: relative;
  display: flex;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul {
  margin: 0;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li {
  border-left: 6px solid rgba(44, 160, 28, 0);
  position: relative;
}

.ms-tabs-position-top .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li {
  border-left: none;
  height: 58px;
  padding: 14px 0 2px;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .active-item {
  z-index: 2;
}

.ms-tabs-position-top .con-ms-ul-tabs .ms-tabs-ul .active-item {
  border-bottom: 4px solid #2ca01c;
}

.ms-tabs-position-top .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li .ms-tabs-btn {
  margin: 0;
  padding: 14px 20px;
}
.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li .ms-tabs-btn {
  display: block;
  position: relative;
  width: 100%;
  background: transparent;
  border: 0;
  border-radius: 30px;
  cursor: pointer;
  transition: all 0.2s ease;
  z-index: 0;
  font-size: 13px;
  color: #111;
}

.con-ms-tabs
  .con-ms-ul-tabs
  .ms-tabs-ul
  .ms-tabs-li
  .ms-tabs-btn:hover:not(:disabled) {
  color: #2ca01c;
}

.con-ms-tabs
  .con-ms-ul-tabs
  .ms-tabs-ul
  .active-item
  :not(:disabled)
  .tab-label {
  color: #111;
  font-weight: 700;
  font-size: 13px;
}
.ms-label {
  text-align: center;
  white-space: nowrap;
  font-size: 13px;
}

.con-ms-tabs
  .con-ms-ul-tabs
  .ms-tabs-ul
  .active-item
  :not(:disabled):hover:not(:disabled)
  .tab-label {
  color: #2ca01c;
}

.ms-tabs-position-top .line-ms-tabs {
  width: 100px;
  height: 2px;
  top: 35px;
  display: block;
  position: absolute;
  transition: all 0.2s ease;
  transform: translateZ(0);
  will-change: left, right;
}

.ms-tabs-position-top .line-bottom {
  width: 100%;
  height: 2px;
  background: #d4d7dc;
  top: 57px;
  z-index: -1;
}
/**bảng các lựa chọn */
.form-process {
  flex-direction: column;
  justify-content: center;
  height: calc(100vh - 112px);
  overflow: auto;
}

.form-process .vertical-center {
  width: 100%;
  justify-content: center;
}

.form-process .vertical-center .process-area {
  background-color: #fff;
  border: 1px solid #e5e5e5;
  border-radius: 3px;
  width: 690px;
  height: 380px;
}

.form-process .vertical-center .title {
  text-transform: uppercase;
  height: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 14px;
  font-weight: 700;
  border-bottom: 1px solid #e5e5e5;
}

.form-process .vertical-center .process-area .content-area .content {
  position: relative;
  display: block;
}

.form-process
  .vertical-center
  .process-area
  .content-area
  .content
  .div-face-button {
  width: 90px;
  padding-top: 60px;
  position: absolute;
  transition: all 0.2s ease;
  text-align: center;
}

.form-process .hoverable:hover {
  cursor: pointer;
  box-shadow: 4px 4px #babec5;
  box-shadow: 0 3px 6px rgb(0 0 0 / 16%);
}

.receive {
  top: 40px;
  left: 90px;
}

.payment {
  top: 215px;
  left: 90px;
}

.audit {
  top: 125px;
  left: 335px;
  width: 125px !important;
}

.form-process
  .vertical-center
  .process-area
  .content-area
  .content
  .div-face-button
  .title-button {
  display: flex;
  justify-content: center;
  height: 100%;
  align-items: flex-end;
  padding-bottom: 10px;
}

/**thanh chọn bên dưới */
.form-process .vertical-center .dictionary-area {
  background-color: #fff;
  border: 1px solid #e5e5e5;
  border-radius: 3px;
  margin-top: 10px;
  height: 70px;
}

.form-process
  .vertical-center
  .dictionary-area
  .dictionary-item:not(:last-child) {
  border-right: 1px solid #e5e5e5;
}

.form-process .vertical-center .dictionary-area .dictionary-item {
  display: flex;
  align-items: center;
  justify-content: center;
}

.form-process
  .vertical-center
  .dictionary-area
  .dictionary-item
  .dictionary-content {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.form-process
  .vertical-center
  .dictionary-area
  .dictionary-item
  .dictionary-content
  .text {
  text-align: center;
}

/**Báo cáo */
.form-process .vertical-center .report-area {
  background-color: #fff;
  border: 1px solid #e5e5e5;
  border-radius: 3px;
  margin-left: 10px;
  width: 300px;
  height: 460px;
  display: flex;
  flex-direction: column;
  position: relative;
}

.form-process .vertical-center .report-area .favorite-report {
  flex: 1;
  overflow: auto;
  min-height: 0;
}

.form-process .vertical-center .report-area .favorite-report ul {
  margin: 0;
  padding: 0 16px;
}

.form-process .vertical-center .report-area .favorite-report ul li {
  display: flex;
  align-items: center;
  padding: 16px 0;
  border-bottom: 1px solid #e5e5e5;
  height: 74px;
}

.form-process .vertical-center .report-area .favorite-report ul li:before {
  content: "\2022";
  color: #646464;
  font-size: 24px;
  margin-right: 12px;
}

.form-process .vertical-center .report-area .favorite-report ul li:hover {
    cursor: pointer;
    color: #0075c0;
}

.form-process .vertical-center .report-area .favorite-report ul li:last-child {
    border-bottom: none;
    height: 75px;
}

.form-process .vertical-center .report-area .footer{
    border-top: 1px solid #e5e5e5;
    cursor: pointer;
    height: 44px;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 13px;
    color: #0075c0;
    background-color: #fff;
}
</style>