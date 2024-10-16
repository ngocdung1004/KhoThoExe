
-- Bảng Users (Lưu thông tin người dùng)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(255),
    Email NVARCHAR(255) UNIQUE,
    PasswordHash NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(MAX),
    UserType NVARCHAR(50), -- 'Customer', 'Worker'
    ProfilePicture NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng Workers (Lưu thông tin chi tiết của thợ)
CREATE TABLE Workers (
    WorkerID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    JobType NVARCHAR(255), -- Loại nghề nghiệp (thợ điện, thợ ống nước, v.v.)
    ExperienceYears INT,
    Rating FLOAT DEFAULT 0,
    Bio NVARCHAR(MAX),
    Verified BIT DEFAULT 0, -- Xác minh thợ đã được duyệt hay chưa
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Subscriptions (Quản lý các gói dịch vụ mà thợ đăng ký để xuất hiện trên nền tảng)
CREATE TABLE Subscriptions (
    SubscriptionID INT PRIMARY KEY IDENTITY(1,1),
    WorkerID INT,
    SubscriptionType NVARCHAR(50), -- 'Monthly', 'Yearly'
    PaymentStatus NVARCHAR(50) DEFAULT 'Pending', -- 'Pending', 'Completed', 'Failed'
    StartDate DATETIME,
    EndDate DATETIME,
    QRCode NVARCHAR(255), -- Mã QR cho việc thanh toán
    FOREIGN KEY (WorkerID) REFERENCES Workers(WorkerID)
);

-- Bảng Reviews (Lưu đánh giá của khách hàng về thợ)
CREATE TABLE Reviews (
    ReviewID INT PRIMARY KEY IDENTITY(1,1),
    WorkerID INT,
    CustomerID INT,
    Rating INT CHECK (Rating >= 1 AND Rating <= 5), -- Đánh giá từ 1 đến 5
    Comments NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (WorkerID) REFERENCES Workers(WorkerID),
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);

-- Bảng Payments (Lưu các giao dịch thanh toán của thợ)
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    WorkerID INT,
    Amount DECIMAL(10, 2), -- Số tiền thanh toán
    PaymentMethod NVARCHAR(50), -- 'QR', 'BankTransfer', 'Other'
    PaymentStatus NVARCHAR(50) DEFAULT 'Pending', -- 'Pending', 'Completed', 'Failed'
    PaidAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (WorkerID) REFERENCES Workers(WorkerID)
);

-- Bảng JobTypes (Danh mục các loại nghề nghiệp)
CREATE TABLE JobTypes (
    JobTypeID INT PRIMARY KEY IDENTITY(1,1),
    JobTypeName NVARCHAR(255) UNIQUE -- Tên loại nghề (thợ điện, thợ sửa ống nước, v.v.)
);

-- Bảng WorkerJobTypes (Liên kết giữa thợ và loại nghề nghiệp)
CREATE TABLE WorkerJobTypes (
    WorkerID INT,
    JobTypeID INT,
    PRIMARY KEY (WorkerID, JobTypeID),
    FOREIGN KEY (WorkerID) REFERENCES Workers(WorkerID),
    FOREIGN KEY (JobTypeID) REFERENCES JobTypes(JobTypeID)
);
