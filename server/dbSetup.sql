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

-- this select has all of the columns generated that my CryptidEncounterProfile DTO uses
SELECT 
  accounts.*,
  cryptid_encounters.id AS cryptid_encounter_id, -- virtual column using the id of the many-to-many
  cryptid_encounters.cryptid_id AS cryptid_id -- virtual column using the cryptidId of the many-to-many
  FROM cryptid_encounters
  JOIN accounts ON accounts.id = cryptid_encounters.account_id;

-- creates a virtual table (view) that you can select from, limit, query, join with etc.
CREATE VIEW cryptid_encounter_profiles_view AS
  SELECT 
  accounts.*,
  cryptid_encounters.id AS cryptid_encounter_id,
  cryptid_encounters.cryptid_id AS cryptid_id
  FROM cryptid_encounters
  JOIN accounts ON accounts.id = cryptid_encounters.account_id;

-- select all from virtual table
SELECT * FROM cryptid_encounter_profiles_view;

-- can still run where clauses, limits, orders, etc.
SELECT * FROM cryptid_encounter_profiles_view WHERE cryptid_id = 11;

-- counts how many encounters have been had with cryptid 11
SELECT COUNT(*) FROM cryptid_encounters WHERE cryptid_id = 11;

SELECT
cryptids.*,
-- COUNT is a sql function that will count columns, which we store in a virtual column(encounter_count)
COUNT(cryptid_encounters.id) AS encounter_count 
FROM cryptids
-- left join will always bring in data on the left of the row (cryptids) but still join data without a match on the right of the row (cryptid_encounters)
LEFT JOIN cryptid_encounters ON cryptids.id = cryptid_encounters.cryptid_id
-- summarizes the joined rows (cryptid_encounters)
GROUP BY(cryptids.id);

-- virtual table with encounter_count column
CREATE VIEW cryptids_with_encounter_count_view AS
  SELECT
  cryptids.*,
  COUNT(cryptid_encounters.id) AS encounter_count 
  FROM cryptids
  LEFT JOIN cryptid_encounters ON cryptids.id = cryptid_encounters.cryptid_id
  GROUP BY(cryptids.id);