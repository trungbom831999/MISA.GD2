<template>
  <div class="navbar-sticky">
    <header class="flex">
      <div class="flex header-branch">
        <div class="header-branch-name">
          CÔNG TY TNHH NƯỚC UỐNG TINH KHIẾT SÀI GÒN
        </div>
        <a class="flex items-center"
          ><div
            class="header-icon mi mi-14 mi-chevron-right header-branch-icon pointer"
          ></div
        ></a>
      </div>
      <div class="header-current-db">
        <div class="icon-header-current-db"></div>
        <div class="header-current-db-name">NỘI BỘ</div>
      </div>

      <div class="spacer"></div>

      <div class="flex header-quick-search">
        <div class="ms-input">
          <input
            id="navbar-search"
            class="input-search hasIcon"
            type="text"
            placeholder="Nhập từ khóa tìm kiếm"
          />
          <label
            class="icon-inputx notranslate ms-input--icon icon-after mi-search mi mi-16"
            for="navbar-search"
          ></label>
        </div>
      </div>

      <div class="header-menu-icon extend-feature-btn">
        <button name="button" class="ms-button" title="Tính năng mở rộng">
          <div class="ms-button-text flex align-center">
            <a href="" class="flex items-center">
              <div class="header-icon mi mi-24 mi-category pointer"></div>
            </a>
          </div>
        </button>
      </div>

      <div class="header-menu-icon">
        <button name="button" class="ms-button" title="Thiết lập">
          <div class="ms-button-text flex align-center">
            <a href="" class="flex items-center">
              <div class="header-icon mi mi-24 mi-setting__nav"></div>
            </a>
          </div>
        </button>
      </div>

      <div class="header-menu-icon">
        <button name="button" class="ms-button" title="Tư vấn sử dụng">
          <div class="ms-button-text flex align-center">
            <a href="" class="flex items-center">
              <div class="header-icon mi mi-24 mi-chat__nav"></div>
            </a>
          </div>
        </button>
      </div>

      <div class="header-menu-icon">
        <button name="button" class="ms-button" title="Giúp">
          <div class="ms-button-text flex align-center">
            <a href="" class="flex items-center">
              <div class="header-icon mi mi-24 mi-help__nav"></div>
            </a>
          </div>
        </button>
      </div>

      <div class="header-menu-icon">
        <button name="button" class="ms-button" title="Thông báo">
          <div class="ms-button-text flex align-center">
            <a href="" class="flex items-center">
              <div class="header-icon mi mi-24 mi-bell__nav"></div>
              <div class="notifyno">2</div>
            </a>
          </div>
        </button>
      </div>

      <div class="account-info flex">
        <button class="ms-button button-account">
          <div class="ms-button-text flex align-center">
            <div class="user-avatar">
              <div
                data-v-3feb680a=""
                data-v-3bfca02f=""
                class="mi mi-32 mi-user-avatar avatar"
              >
                <img src="" />
              </div>
            </div>
            <div class="user-name pr-0">Nguyễn Kiên Trung</div>
            <div class="mi mi-14 mi-chevron-down pointer"></div>
          </div>
        </button>
      </div>
    </header>
  </div>
</template>

<style>
header {
  background-color: #fff;
  padding: 0;
  height: 48px;
  clear: both;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-align: center;
  -ms-flex-align: center;
  align-items: center;
  -webkit-box-pack: justify;
  -ms-flex-pack: justify;
  justify-content: space-between;
  -webkit-box-shadow: 0 4px 20px 0 rgb(0 0 0 / 5%);
  box-shadow: 0 4px 20px 0 rgb(0 0 0 / 5%);
  width: 100%;
  z-index: 10000;
  position: relative;
}

.navbar-sticky {
  padding: 0;
  background: none;
  z-index: 1000;
  top: 0;
  position: absolute;
  width: 100%;
}

/*Tên công ty */
.header-branch {
  cursor: pointer;
}

.header-branch-name {
  padding-left: 20px;
  overflow: hidden;
  white-space: nowrap;
  font-weight: 600;
  max-width: 800px;
  text-overflow: ellipsis;
  transition: all 0.2s ease;
  font-size: 14px;
  color: #111;
}

@media (max-width: 1680px) {
  .header-branch-name {
    max-width: 450px;
  }
}

@media (max-width: 1440px) {
  .header-branch-name {
    max-width: 300px;
  }
}

@media (max-width: 1300px) {
  .header-branch-name {
    max-width: 200px;
  }
}

@media (max-width: 900px) {
  .header-branch-name {
    max-width: 100px;
  }
}

.header-branch-icon {
  transform: rotate(90deg);
  margin-left: 10px;
}

.header-icon {
  margin: 0 10px;
}



/**Db hiện tại */
.header-current-db {
  display: flex;
  align-items: center;
  border: 1px solid #ebedf0;
  padding: 0 12px;
  border-radius: 40px;
  margin-left: 15px;
  font-size: 13px;
  cursor: pointer;
  height: 30px;
  margin-right: 10px;
}

.icon-header-current-db {
  width: 8px;
  height: 8px;
  background-color: #4ea344;
  border-radius: 50%;
  border: 1px solid #fff;
}

.header-current-db-name {
  padding-left: 7px;
  max-width: 200px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  transition: all 0.2s ease;
  color: #111;
}

/**khoảng trống */
.spacer {
  display: block !important;
  padding: 0;
  margin: 0;
  -webkit-box-flex: 1 !important;
  -ms-flex-positive: 1 !important;
  flex-grow: 1 !important;
  background: transparent;
}

/**thanh tìm kiếm */
.header-quick-search {
  margin-right: 20px;
  width: 200px;
}

.ms-input {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  position: relative;
  justify-content: center;
  color: #111;
  width: 100%;
  border-radius: 3px;
}

.ms-input .hasIcon {
  padding-left: 0.85em;
  padding-right: 1.75rem;
}

.input-search {
  background: #fff;
  border-radius: 3px;
  color: #111;
  border: 1px solid #ebedf0;
  font-size: 13px;
  height: 32px;
  box-sizing: border-box;
  width: 100%;
}

.input-search::-webkit-input-placeholder {
  color: #92969c;
  font-style: italic;
  font-weight: 500;
  font-size: 12px;
}

.input-search:hover {
  border: 1px solid #e2e2e2;
}

.ms-input .input-search:focus {
    border: 1px solid #2ca01c !important;
}

.icon-after {
  position: absolute;
  left: auto;
  right: 5px;
  top: 8px;
  border-right: 0;
  padding-left: 3px;
  margin-right: 4px;
  user-select: none;
}

/**Các nút chứa icon trên header */
.header-menu-icon {
  position: relative;
  height: 48px;
  width: 44px;
}

.header-menu-icon:hover {
  cursor: pointer;
  background-color: #000;
}

.header-menu-icon:hover:after {
  content: "";
  width: 0;
  height: 0;
  border-bottom: 8px solid transparent;
  border-left: 22px solid transparent;
  border-right: 22px solid transparent;
  border-top: 8px solid #000;
  position: absolute;
  bottom: -16px;
  left: 0;
}

.extend-feature-btn:hover {
  background-color: #2ca01c;
}

.extend-feature-btn:hover:after {
  border-top: 8px solid #2ca01c;
}

.ms-button {
  border: 0;
  cursor: pointer;
  position: relative;
  overflow: hidden;
  color: #fff;
  background: transparent;
  overflow: visible;
  height: 100%;
  transition: all .2s ease;
}

.ms-button .ms-button-text {
  font-weight: 600;
  position: relative;
  color: inherit;
  display: inline-block;
  transition: all 0.25s ease;
  white-space: nowrap;
  font-size: 13px;
  line-height: 13px;
  /* margin-top: 8px; */
}

.header-icon {
  margin: 0 10px;
}

.notifyno,
.notifySyncno {
  background: #ff6e6e;
  height: 18px;
  border: none;
  border-radius: 18px;
  font-size: 10px;
  color: #fff;
  position: absolute;
  top: -8px;
  padding: 2px 6px;
}

.notifyno {
  right: 4px;
}

/**Phần thông tin cá nhân trên header */
.account-info {
  padding-right: 20px;
}

.ms-button-secondary {
  border: unset;
  color: unset;
  background: unset;
}

.button-account {
  padding: 0 16px !important;
  height: 36px;
  position: relative;
  border-radius: 3px;
}

.user-avatar {
  background: #e2e2e2;
  margin-right: 6px;
  border-radius: 15px;
}

.user-avatar .avatar {
  border-radius: 50%;
}

.user-name {
  align-items: center;
  color: #111;
  font-size: 15px;
  display: flex;
  margin-right: 8px;
}
</style>