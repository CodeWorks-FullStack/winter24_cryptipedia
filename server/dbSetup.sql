CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE cryptids(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name TINYTEXT NOT NULL,
  description TEXT NOT NULL,
  img_url TEXT NOT NULL,
  threat_level TINYINT UNSIGNED NOT NULL,
  origin ENUM('terrestrial', 'aquatic', 'hominid', 'flying') NOT NULL,
  size TINYINT UNSIGNED NOT NULL,
  discoverer_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (discoverer_id) REFERENCES accounts(id) ON DELETE CASCADE
);

CREATE TABLE cryptid_encounters(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  account_id VARCHAR(255) NOT NULL,
  cryptid_id INT NOT NULL,
  FOREIGN KEY (account_id) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (cryptid_id) REFERENCES cryptids(id) ON DELETE CASCADE,
  UNIQUE(account_id, cryptid_id)
);


DROP TABLE cryptids;


  SELECT * FROM cryptid_encounters
  JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = 1;